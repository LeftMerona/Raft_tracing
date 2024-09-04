using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State : MonoBehaviour
{
    private Animator animator;

    private bool isJump;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            Jump();
        }
    }

    private void Jump()
    {
        isJump = true;
        transform.Translate(Vector3.up * 5f * Time.deltaTime);
        isJump = false;
    }
}
