using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PickUpItem : MonoBehaviour
{
    private Transform PickUpPoint;
    private Transform player;
    public Transform camera;

    public float pickUpDistance;
    public float forceMulti;

   // public Slider ThrowForce;
    public Image radialIndicator;
    public GameObject PickupText;

    public bool readyToThrow;
    public bool itemIsPicked;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        PickUpPoint = GameObject.Find("PickUpPoint").transform;
        camera = GameObject.Find("Camera").transform;
        PickupText.SetActive(false);
    }

    public void SliderChange()
    {
       // ThrowForce.value = forceMulti;
        radialIndicator.fillAmount = forceMulti / 1000;
    }
    // Update is called once per frame
    void Update()
    {
        SliderChange();

        if(Input.GetKey(KeyCode.E) && itemIsPicked == true && readyToThrow)
        {
            forceMulti += 300 * Time.deltaTime;
            forceMulti = Mathf.Clamp(forceMulti, 0, 1000);
        }


        pickUpDistance = Vector3.Distance(player.position, transform.position);

        if(pickUpDistance <= 2)
        {
            if (PickUpPoint.childCount == 0 && PickupText.active == false)
            {
                PickupText.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E) && itemIsPicked == false && PickUpPoint.childCount < 1)
            {
                PickupText.SetActive(false);
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<SphereCollider>().enabled = false;
                this.transform.position = PickUpPoint.position;
                this.transform.rotation = PickUpPoint.rotation;
                this.transform.parent = GameObject.Find("PickUpPoint").transform;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                itemIsPicked = true;
                forceMulti = 0;
            }
        }
        else
        {
            PickupText.SetActive(false);
        }

        if(Input.GetKeyUp(KeyCode.E) && itemIsPicked == true)
        {
            readyToThrow = true;
            if(forceMulti > 10)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                rb.AddForce(camera.transform.forward * forceMulti);
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<SphereCollider>().enabled = true;
                itemIsPicked = false;
                forceMulti = 0;
                readyToThrow = false;
            }

            forceMulti = 0;
        }
    }
}
