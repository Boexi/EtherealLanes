using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject ExitButton;
    public GameObject ControlsButton;
    public GameObject CameraButton;
    public GameObject GraphicsButton;
    public GameObject AudioButton;

    [Header("Self Reference")]
    public GameObject SettingsPage;

    [Header("Pages")]
    public GameObject ControlsPage;
    public GameObject CameraPage;
    public GameObject GraphicsPage;
    public GameObject AudioPage;

    [Header("Title")]
    public GameObject Title;



    public void ExitMenu()
    {
        //Title.SetActive(true);
        SettingsPage.SetActive(false);
        AudioPage.SetActive(false);
        ControlsPage.SetActive(false);
        CameraPage.SetActive(false);
        GraphicsPage.SetActive(false);

    }


    public void openControls()
    {
        AudioPage.SetActive(false);
        ControlsPage.SetActive(true);
        CameraPage.SetActive(false);
        GraphicsPage.SetActive(false);
    }

    public void openCamera()
    {
        AudioPage.SetActive(false);
        ControlsPage.SetActive(false);
        CameraPage.SetActive(true);
        GraphicsPage.SetActive(false);
    }

    public void openGraphics()
    {
        AudioPage.SetActive(false);
        ControlsPage.SetActive(false);
        CameraPage.SetActive(false);
        GraphicsPage.SetActive(true);
    }

    public void openAudio()
    {
        AudioPage.SetActive(true);
        ControlsPage.SetActive(false);
        CameraPage.SetActive(false);
        GraphicsPage.SetActive(false);
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
