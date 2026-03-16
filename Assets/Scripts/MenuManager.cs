using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject CloseButton;
    public GameObject Title;
    public GameObject CreditsButton;
    public GameObject BackButton;
    public GameObject CreditText;
    public GameObject ControlsText;
    public GameObject ControlsButton;
    public GameObject SettingsButton;
    public GameObject SettingsPage;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenSettings()
    {
        SettingsPage.SetActive(true);
    }

    public void Credits()
    {
        StartButton.SetActive(false);
        CloseButton.SetActive(false);
        Title.SetActive(false);
        CreditsButton.SetActive(false);
        BackButton.SetActive(true);
        ControlsButton.SetActive(false);
        CreditText.SetActive(true);
    }

    public void Controls()
    {
        StartButton.SetActive(false);
        CloseButton.SetActive(false);
        ControlsButton.SetActive(false);
        Title.SetActive(false);
        CreditsButton.SetActive(false);
        BackButton.SetActive(true);
        ControlsText.SetActive(true);
    }

    public void CloseCredits()
    {
        StartButton.SetActive(true);
        CloseButton.SetActive(true);
        Title.SetActive(true);
        CreditsButton.SetActive(true);
        BackButton.SetActive(false);
        CreditText.SetActive(false);
        ControlsButton.SetActive(true);
        ControlsText.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game pressed");

        Application.Quit();
    }
}
