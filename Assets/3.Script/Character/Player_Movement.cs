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



    private void Awake()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveWS_Value = Input.GetAxis(_moveWSAxis_name);
        MoveAD_Value = Input.GetAxis(_moveADAxis_name);

        var movedir = new Vector3(MoveAD_Value, 0, MoveWS_Value).normalized * movespeed * Time.deltaTime;
        rb.MovePosition(transform.position + (transform.forward * movedir.z) + (transform.right * movedir.x));
    }

    private void LateUpdate()
    {
        MovePosition();
    }

    private void MovePosition()
    {

        ani.SetFloat("VelocityX", MoveAD_Value);
        ani.SetFloat("VelocityZ", MoveWS_Value);
    }




}
