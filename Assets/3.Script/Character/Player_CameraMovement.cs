using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Cinemachine;

public class Player_CameraMovement : MonoBehaviour
{
    [SerializeField] private CursorManager cursorManager;
    [SerializeField] private GameObject upperbody;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachinePOV povcamera;

    private float upperbodyRotation = 0f;

    private void Start()
    {
        povcamera = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }

    private void LateUpdate()
    {
        if (!cursorManager.IsOpen)
        {
            MoveMousePosition();
        }
    }

    private void MoveMousePosition()
    {
        // �¿� ȸ���� ��ü, ��ü�� ������ ���߱�
        transform.localRotation = Quaternion.Euler(0, povcamera.m_HorizontalAxis.Value, 0f);
        upperbody.transform.localRotation = Quaternion.Euler(0, povcamera.m_VerticalAxis.Value, 0);


        // �Ϲ� MainCamera ��� ��, ĳ���� ȸ�� ���� ��ġ ��Ű�ų� ��� ��Ű�� �ʹ� ��鸮�� ���߱� ������� 
        // Virtual ī�޶� ä���ؼ� Pov�� �����ϰ�  ó�� 
    }


}
