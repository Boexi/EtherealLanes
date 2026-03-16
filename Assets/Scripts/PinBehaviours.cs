using UnityEngine;
using System.Collections;

public class PinBehaviours : MonoBehaviour
{

    public LayerMask laneMask;
    private bool isUpright;
    public Ray myRay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        isUpright = Physics.Raycast(transform.position, Vector3.down, 9.5f, laneMask);

        if (!isUpright)
        {
            StartCoroutine(PinManagement());
        }
    }

    IEnumerator PinManagement()
    {
        //yield return new WaitForSecondsRealtime(1f);
        //if (isUpright)
        //{
        //    Debug.Log("stood back up");
        //    yield return null;
        //}
        yield return new WaitForSecondsRealtime(2.5f);

            GameObject.Destroy(this.gameObject);
        
    }
}
