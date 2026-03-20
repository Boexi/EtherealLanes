using UnityEngine;
using PurrNet;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    [Header("Player set up")]
    public GameObject Player;
    public Camera cam;
    public Rigidbody rb;

    [SerializeField]
    [Header("Speed settings")]
    public float walkSpeed = 5f;
    public float jumpForce = 5f;

    [SerializeField]
    [Header("Masks")]
    public LayerMask groundMask;

    [SerializeField]
    [Header("Booleans")]
    public bool isGrounded;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = (transform.forward * v + transform.right * h) * walkSpeed;
        Vector3 newVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        rb.linearVelocity = newVelocity;

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 2f, groundMask);
        // was 1.6f (in case of any issues)
    }
}
