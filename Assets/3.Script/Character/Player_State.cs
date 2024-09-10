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

    private bool isGround;
    private Vector3 rayshoot = new Vector3(0, -0.5f, 0);

    private void Awake()
    {
        isGround = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //아래로 레이쏘며 바다인지 땅인지
        CheckGround();


        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
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
        animator.SetBool("isGround", false);
        animator.SetTrigger("JumpStart");
        rb.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);

        isJump = false;
        animator.SetBool("isGround", true);
    }


    private void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, rayshoot, out hit))
        {
            Debug.DrawRay(transform.position, rayshoot, Color.red);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

}
