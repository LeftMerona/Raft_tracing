using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100.0f;

    [SerializeField] private string _moveAxis_name = "Vertical";
    [SerializeField] private string _rotateAxis_name = "Horizontal";
    [SerializeField] private float velocityX;
    [SerializeField] private float velocityZ;

    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        ani.SetFloat("VelocityX", 0.5f);
        ani.SetFloat("VelocityZ", 0.5f);
    }


    public float Move_Value { get; private set; }
    public float Rotate_Value { get; private set; }

    private void Update()
    {
        Move_Value = Input.GetAxis(_moveAxis_name);
        Rotate_Value = Input.GetAxis(_rotateAxis_name);

        ani.SetFloat("VelocityX", Move_Value);
        ani.SetFloat("VelocityZ", Rotate_Value);
    }

}
