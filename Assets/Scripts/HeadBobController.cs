//Code written by Brock Hymus 11/03/26 - Unlicense

using UnityEngine;
using UnityEngine.InputSystem;

public class HeadBob : MonoBehaviour
{
    //Reference to camera
    public Transform cameraTransform;

    [Header("Bob Settings")]
    //How fast head moves
    public float frequency = 8f;
    //Strength of bobbing
    public float amplitude = 0.05f;

    [Header("Input")]
    //Movement reference
    public InputActionReference moveAction;

    //used for the sin and cosine
    float timer;

    //Camera original location
    Vector3 startPos;

    void Start()
    {
        //Recording camera start position. Bobbing relative to the start
        startPos = cameraTransform.localPosition;
    }

    void Update()
    {
        Vector2 movement = moveAction.action.ReadValue<Vector2>();

        //if player is moving
        if (movement.magnitude > 0.1f)
        {

            //Increases timer based on time and bob frequency
            timer += Time.deltaTime * frequency;

            //bob up and down (weaker)
            float bobX = Mathf.Cos(timer) * amplitude * 0.5f;
            //bob side to side (stronger)
            float bobY = Mathf.Sin(timer * 2) * amplitude;

            //applies offset relative to starting position
            cameraTransform.localPosition = startPos + new Vector3(bobX, bobY, 0);
        }
        else
        {
            //if player stops moving, reset timer and lerp back to original position
            timer = 0;

            cameraTransform.localPosition = Vector3.Lerp(
                cameraTransform.localPosition,
                startPos,
                Time.deltaTime * 6f
            );
        }
    }
}