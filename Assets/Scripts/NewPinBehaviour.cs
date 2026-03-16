using UnityEngine;

public class NewPinBehaviour : MonoBehaviour
{

    public Transform pin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public LayerMask laneMask;
    private bool knockedOver;

    private void Update()
    {
        this.transform.position = pin.position;
        this.transform.rotation = pin.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GameObject.Destroy(this.transform.parent);
        }
    }


}
