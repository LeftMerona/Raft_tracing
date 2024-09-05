using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State : MonoBehaviour
{
    [SerializeField] GameObject _RightHand;

    private Animator animator;
    private Rigidbody rb;
    private bool isJump;
    private int _ItemID;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
             
        }

    }

    private void Jump()
    {
        isJump = true;
        rb.MovePosition(transform.position + Vector3.up * 30f * Time.deltaTime);

        isJump = false;
    }
}
