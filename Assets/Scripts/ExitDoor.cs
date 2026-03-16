using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public GameObject leavePanel;
    public GameObject UI;
    public CameraController camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leavePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            camera.GetComponent<CameraController>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leavePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            camera.GetComponent<CameraController>().enabled = true;
        }
    }

    public void YES()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NO()
    {
        leavePanel.SetActive(false);
        camera.GetComponent<CameraController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UI.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        
    }
}
