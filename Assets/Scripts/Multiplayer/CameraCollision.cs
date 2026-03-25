using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 5f;
    public float minDistance = 1f;
    public float smoothSpeed = 10f;

    private Vector3 dollyDir;
    private float currentDistance;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dollyDir = transform.localPosition.normalized;
        currentDistance = transform.localPosition.magnitude;
        
    }


    private void LateUpdate()
    {
        Vector3 desiredCamPos = target.TransformPoint(dollyDir * maxDistance);

        RaycastHit hit;

        if (Physics.Raycast(target.position, desiredCamPos - target.position, out hit, maxDistance, ~0, QueryTriggerInteraction.Ignore))
        {
            currentDistance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
        }
        else
        {
            currentDistance = maxDistance;
        }

        //Physics.Raycast(target.position, desiredCamPos - target.position, out hit, maxDistance, ~0, QueryTriggerInteraction.Ignore);


        Vector3 newPos = target.TransformPoint(dollyDir * currentDistance);
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * smoothSpeed);
    }
}
