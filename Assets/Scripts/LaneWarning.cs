using UnityEngine;

public class LaneWarning : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject laneWarningMessage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            laneWarningMessage.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            laneWarningMessage.SetActive(false);
        }
    }

}
