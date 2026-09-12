using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

/// <summary>
/// A class which manages pages of UI elements
/// and the game's UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Page Management")]
    [Tooltip("The pages (Panels) managed by the UI Manager")]
    public List<UIPage> pages;

    [Tooltip("The index of the active page in the UI")]
    public int currentPage = 0;

    [Tooltip("The page (by index) switched to when the UI Manager starts up")]
    public int defaultPage = 0;

    [Header("Pause Settings")]
    [Tooltip("The index of the pause page in the pages list")]
    public int pausePageIndex = 1;

    [Tooltip("Whether or not to allow pausing")]
    public bool allowPause = true;

    [Header("Input Actions & Controls")]
    public InputAction pauseAction;

    // Whether or not the application is paused
    private bool isPaused = false;

    // A list of all UI element classes
    private List<UIelement> UIelements;

    // The event system handling UI navigation
    [HideInInspector]
    public EventSystem eventSystem;

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    private void SetUpUIElements()
    {
        UIelements = FindObjectsOfType<UIelement>().ToList();
    }

    private void SetUpEventSystem()
    {
        eventSystem = FindObjectOfType<EventSystem>();

        if (eventSystem == null)
        {
            Debug.LogWarning(
                "There is no event system in the scene but you are trying to use the UIManager. \n" +
                "All UI in Unity requires an Event System to run. \n" +
                "You can add one by right clicking in hierarchy then selecting UI->EventSystem."
            );
        }
    }

    public void TogglePause()
    {
        if (allowPause)
        {
            if (isPaused)
            {
                SetActiveAllPages(false);
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                GoToPage(pausePageIndex);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }

    public void UpdateUI()
    {
        SetUpUIElements();

        foreach (UIelement uiElement in UIelements)
        {
            uiElement.UpdateUI();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        SetUpEventSystem();
        SetUpUIElements();
        UpdateUI();
    }

    private void Update()
    {
        CheckPauseInput();
    }

    private void CheckPauseInput()
    {
        if (pauseAction.triggered)
        {
            TogglePause();
        }
    }

    public void GoToPage(int pageIndex)
    {
        if (pageIndex < pages.Count && pages[pageIndex] != null)
        {
            SetActiveAllPages(false);

            pages[pageIndex].gameObject.SetActive(true);

            pages[pageIndex].SetSelectedUIToDefault();
        }
    }

    public void GoToPageByName(string pageName)
    {
        UIPage page = pages.Find(item => item.name == pageName);

        int pageIndex = pages.IndexOf(page);

        GoToPage(pageIndex);
    }

    public void SetActiveAllPages(bool activated)
    {
        if (pages != null)
        {
            foreach (UIPage page in pages)
            {
                if (page != null)
                {
                    page.gameObject.SetActive(activated);
                }
            }
        }
    }

    // Returns to the Main Menu page
    public void BackToMainMenu()
    {
        Debug.Log("BACK TO MAIN MENU BUTTON CLICKED");

        SetActiveAllPages(false);

        if (pages.Count > 0 && pages[0] != null)
        {
            pages[0].gameObject.SetActive(true);
            pages[0].SetSelectedUIToDefault();
        }
    }
}