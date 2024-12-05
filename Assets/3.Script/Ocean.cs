using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Entity_Head") && other.transform.root.TryGetComponent<Player_State>(out Player_State state))
        {   
            if (!state.IsOcean)
            {
                state.ChangeisGround();
                state.PlayerRigidbody.useGravity = false;
                state.PlayerRigidbody.velocity = Vector3.zero; 
            }
            else
            {
                state.ChangeisGround();
                state.PlayerRigidbody.useGravity = true;
            }
        }

    }


}
