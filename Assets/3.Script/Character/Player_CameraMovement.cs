using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player_CameraMovement : MonoBehaviour
{
    [SerializeField] private CursorManager cursorManager;
    private float _mouseX;
    private float _mouseY;
    [SerializeField] private GameObject head_camerapivot;
    [SerializeField] private GameObject maincamera;

    [SerializeField] private GameObject camerapivot;
    [SerializeField] private GameObject armsObj;

    private float currentHeadRotation = 0f;
    private void Update()
    {
        if (!cursorManager.IsOpen)
        {
            // X ���� Y ���� 
            _mouseX = Input.GetAxis("Mouse X");
            _mouseY = Input.GetAxis("Mouse Y");

            currentHeadRotation -= _mouseY;
            currentHeadRotation = Mathf.Clamp(currentHeadRotation, -90, 90);
        }
    }

    private void LateUpdate()
    {
        MoveMousePosition();
    }

    private void MoveMousePosition()
    {
        // ī�޶� ������ �� �κе� ���� 
        transform.Rotate(0, _mouseX, 0); // �� ���� Y �� 

        head_camerapivot.transform.localRotation = Quaternion.Euler(0, currentHeadRotation, 0); // �Ӹ� Y ��
        maincamera.transform.localRotation = Quaternion.Euler(currentHeadRotation, _mouseX, 0);
    }


}
