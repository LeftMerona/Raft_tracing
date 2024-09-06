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
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("JumpStart");
        isJump = true;
        rb.AddForce(Vector3.up * 15f , ForceMode.Impulse);
        animator.SetBool("isGound", false);        

        isJump = false;
    }

     
}
