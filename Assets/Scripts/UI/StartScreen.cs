using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject mainMenu;

    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            startScreen.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}