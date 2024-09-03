using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CharacterCamera_Movement : MonoBehaviour
{
    public float rotationSpeed = 10f;

    [SerializeField] private float _mouseX;
    [SerializeField] private float _mouseY;
    [SerializeField] private GameObject head;

    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;

    }

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
    }

    private void LateUpdate()
    {
       MoveMousePosition();
    }

    private void MoveMousePosition()
    {
        float dir = -_mouseY * rotationSpeed * Time.deltaTime;
        float yrotate = Mathf.Clamp(dir, -60, 50);

        // -60 50 
        transform.Rotate(0, _mouseX, 0);
        head.transform.Rotate( 0, yrotate , 0);
        head.transform.eulerAngles.Set(0, Mathf.Clamp(transform.eulerAngles.y, -60, 50), 0);
    }


}
