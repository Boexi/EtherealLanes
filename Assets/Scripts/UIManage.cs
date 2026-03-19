using UnityEngine;

public class UIManage : MonoBehaviour
{
    public GameObject UI;
    public CameraController camera;

    private bool gamePaused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ContinueGame();
            } else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        gamePaused = true;
        //Time.timeScale = 0;
        camera.GetComponent<CameraController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UI.SetActive(true);
    }

    public void ContinueGame()
    {
        camera.GetComponent<CameraController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gamePaused = false;
        UI.SetActive(false);
        //Time.timeScale = 1;
    }
}
