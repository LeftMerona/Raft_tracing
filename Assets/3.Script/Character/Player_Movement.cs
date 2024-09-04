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

    private Rigidbody rb;
    private Animator ani;

    private bool isGround;

    private void Awake()
    {
        isGround = true;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public float MoveWS_Value { get; private set; }
    public float MoveAD_Value { get; private set; }

    private void Update()
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


}
