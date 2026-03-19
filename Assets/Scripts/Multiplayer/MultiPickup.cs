using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class MultiPickup : NetworkBehaviour
{
    public float pickupDistance = 2f;
    public float maxThrowForce = 1000f;

    public GameObject pickupText;

    private Rigidbody rb;

    private NetworkVariable<bool> isHeld = new NetworkVariable<bool>(false);
    private NetworkVariable<ulong> holderId = new NetworkVariable<ulong>(0);

    float throwCharge;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (pickupText != null)
            pickupText.SetActive(false);
    }

    void Update()
    {
        if (!IsClient) return;

        var player = NetworkManager.Singleton.LocalClient.PlayerObject;
        if (player == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Show pickup text
        if (!isHeld.Value && distance <= pickupDistance)
        {
            if (pickupText != null)
                pickupText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                RequestPickupServerRpc();
            }
        }
        else
        {
            if (pickupText != null)
                pickupText.SetActive(false);
        }

        // If holding the item
        if (isHeld.Value && holderId.Value == NetworkManager.Singleton.LocalClientId)
        {
            HandleThrow();
        }
    }

    void HandleThrow()
    {
        if (Input.GetKey(KeyCode.E))
        {
            throwCharge += 400 * Time.deltaTime;
            throwCharge = Mathf.Clamp(throwCharge, 0, maxThrowForce);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Vector3 dir = GetCameraForward();
            ThrowServerRpc(dir, throwCharge);
            throwCharge = 0;
        }
    }

    Vector3 GetCameraForward()
    {
        var player = NetworkManager.Singleton.LocalClient.PlayerObject;
        Camera cam = player.GetComponentInChildren<Camera>();

        return cam.transform.forward;
    }

    [ServerRpc(RequireOwnership = false)]
    void RequestPickupServerRpc(ServerRpcParams rpcParams = default)
    {
        if (isHeld.Value) return;

        ulong clientId = rpcParams.Receive.SenderClientId;
        var player = NetworkManager.Singleton.ConnectedClients[clientId].PlayerObject;
        Debug.Log("Trying Pickup");
        if (player == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > pickupDistance) return;

        Transform holdPoint = player.transform.Find("PickUpPoint");
        if (holdPoint == null) return;

        rb.isKinematic = true;

        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        isHeld.Value = true;
        holderId.Value = clientId;
    }

    [ServerRpc(RequireOwnership = false)]
    void ThrowServerRpc(Vector3 direction, float force)
    {
        if (!isHeld.Value) return;

        transform.SetParent(null);

        rb.isKinematic = false;
        rb.AddForce(direction * force, ForceMode.Impulse);

        isHeld.Value = false;
    }
}