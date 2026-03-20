using UnityEngine;
using UnityEngine.UI;

public class TitleWobble : MonoBehaviour
{

    public float minRange = -5;
    public float maxRange = 5;
    public float speed = 2;

    public GameObject Settings;
    public Image Title;


    void Update()
    {
        float a = Mathf.SmoothStep(minRange, maxRange, Mathf.PingPong((Time.time / speed) % 2 - 0.5f, 1.0f)); // 3 is the speed
        transform.eulerAngles = new Vector3(0, 0, a);



        if(Settings.active == true)
        {
            Title.GetComponent<Image>().enabled = (false);
        } else
        {
            Title.GetComponent<Image>().enabled = (true);
        }
    }
}

