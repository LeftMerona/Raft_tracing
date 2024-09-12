using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player_State : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public Rigidbody PlayerRigidbody { get => rb; set => rb = value; }
    private int _ItemID;

    protected bool isJump = false;
    public bool IsJump { get => isJump; set => isJump = value; }
    protected bool isGround = true;
    public bool IsGround { get => isGround; set => isGround = value; }
    private bool isOcean = false;
    public bool IsOcean { get => isOcean; set => isOcean = value; }
    protected bool isAir = false; 

    protected string Ocean;
    private Vector3 rayshoot = new Vector3(0, -0.5f, 0);

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //아래로 레이쏘며 바다인지 땅인지? enter  exit로 처리 
        // CheckGround();

        if (!isOcean) // 바다 아닐때 
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJump)
            {
                StartCoroutine(Jump_co());
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {

            }
        }
        else if (isOcean) // isair도 잇어서 
        {

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Eneter;");
            isGround = true;
            isJump = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Eexit");
            isGround = false;
        }
    }

    private IEnumerator Jump_co()
    {
        isJump = true;
        if (animator != null)
        {
            animator.SetBool("isGround", !isGround);
            animator.SetTrigger("JumpStart");
        }      
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

        yield return null;
        animator.SetBool("isGround", isGround);
    }

    private void Jump()
    {
        isJump = true;
        if(animator != null)
        {
            animator.SetBool("isGround", false);
            animator.SetTrigger("JumpStart");
        }

        rb.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);   
        if(transform.position.y < 0.1f)
        {
            isJump = false;
        }

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


    public void SetPlayerRigidBody()
    {
        rb.useGravity = !rb.useGravity;
    }

}
