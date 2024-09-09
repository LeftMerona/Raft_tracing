using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player_CameraMovement : MonoBehaviour
{
    [SerializeField] private float _mouseX;
    [SerializeField] private float _mouseY;
    [SerializeField] private GameObject head_camerapivot;
    [SerializeField] private GameObject maincamera;

    [SerializeField] private GameObject camerapivot;
    [SerializeField] private GameObject armsObj;

    private float currentHeadRotation = 0f;

    private void LateUpdate()
    {
        // X ���� Y ���� 
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");


        MoveMousePosition();
    }

    private void MoveMousePosition()
    {
        currentHeadRotation -= _mouseY;
        currentHeadRotation = Mathf.Clamp(currentHeadRotation, -90, 90);

        // ī�޶� ������ �� �κе� ���� 
        transform.Rotate(0, _mouseX, 0); // �� ���� Y �� 
        
        head_camerapivot.transform.localRotation = Quaternion.Euler(0, currentHeadRotation, 0); // �Ӹ� Y ��
        maincamera.transform.localRotation = Quaternion.Euler(currentHeadRotation, _mouseX, 0);
    }


}
