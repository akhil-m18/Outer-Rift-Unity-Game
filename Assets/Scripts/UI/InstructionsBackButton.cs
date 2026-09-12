using UnityEngine;

public class InstructionsBackButton : MonoBehaviour
{
    public GameObject instructionsPage;
    public GameObject mainMenuPage;

    public void BackToMainMenu()
    {
        instructionsPage.SetActive(false);
        mainMenuPage.SetActive(true);
    }
}