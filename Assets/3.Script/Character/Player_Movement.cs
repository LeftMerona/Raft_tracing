using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : MonoBehaviour
{
    public float movespeed = 1f;

    [SerializeField] private string _moveWSAxis_name = "Vertical";
    [SerializeField] private string _moveADAxis_name = "Horizontal";

    public float MoveWS_Value { get; private set; }
    public float MoveAD_Value { get; private set; }

    private Rigidbody rb;
    private Animator ani;

    private bool isGround;
    private Vector3 rayshoot = new Vector3(0, -0.5f, 0);

    private void Awake()
    {
        isGround = true;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //아래로 레이쏘며 바다인지 땅인지
        CheckGround();
    }

    private void LateUpdate()
    {
        MovePosition();
    }

    private void MovePosition()
    {
        MoveWS_Value = Input.GetAxis(_moveWSAxis_name);
        MoveAD_Value = Input.GetAxis(_moveADAxis_name);

        var movedir = new Vector3(MoveAD_Value, 0, MoveWS_Value).normalized * movespeed * Time.deltaTime;

        if (isGround)
        { // 육지라면 
            ani.SetFloat("VelocityX", MoveAD_Value);
            ani.SetFloat("VelocityZ", MoveWS_Value);
        }
        else
        { // 바다라면?

        }

        rb.MovePosition(transform.position + (transform.forward * movedir.z) + (transform.right * movedir.x));
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
