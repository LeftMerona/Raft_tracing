using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera_Movement : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    [SerializeField] private float _mouseX;
    [SerializeField] private float _mouseY;
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject cameraobj;

    private Rigidbody rb;
    private Animator ani;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveMousePosition();
    }

    private void MoveMousePosition()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;

        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        float yRotate = Mathf.Clamp(_mouseX, -70, 70);

        var mouseDir = new Vector2(_mouseY, yRotate) * rotationSpeed * Time.deltaTime;



        //   chest.transform.Rotate(_mouseX, 0, 0);
        chest.transform.Rotate(mouseDir.x, mouseDir.y, 0);

        
    }


}
