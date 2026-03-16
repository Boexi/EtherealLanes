using UnityEngine;
using System.Collections;

public class TempBallRespawn : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody rb;
    public Vector3 startPos;
    public Quaternion Rotation;

    private void Start()
    {
        startPos = transform.position;
        Rotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(BallRespawn());
            //transform.position = new Vector3(0, 2, -3);
            transform.position = startPos;
            transform.rotation = Rotation;

        }
    }


    IEnumerator BallRespawn()
    {
        rb.freezeRotation = true;
        rb.linearVelocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1f);
        rb.freezeRotation = false;
    }
}
