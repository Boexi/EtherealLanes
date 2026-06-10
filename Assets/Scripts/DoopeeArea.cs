using UnityEngine;

public class DoopeeArea : MonoBehaviour
{
    public GameObject grimble;
    public GameObject doopsic;

    void Start()
    {
        doopsic.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            grimble.SetActive(false);
            doopsic.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            grimble.SetActive(true);
            doopsic.SetActive(false);
        }
    }


}
