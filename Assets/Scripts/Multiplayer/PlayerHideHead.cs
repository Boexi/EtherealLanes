using UnityEngine;
using Unity.Netcode;


public class PlayerHideHead : NetworkBehaviour
{

    public GameObject eyes;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            eyes.SetActive (false);
        }
    }
}
