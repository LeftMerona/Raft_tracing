using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player_CameraMovement : MonoBehaviour
{
    [SerializeField] private CursorManager cursorManager;
    [SerializeField] private GameObject upperbody;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachinePOV povcamera;

    private void Start()
    {
        povcamera = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }

    private void LateUpdate()
    {
        MoveMousePosition();
    }

    private void MoveMousePosition()
    {
        // �¿� ȸ���� ��ü, ��ü�� ������ ���߱�
        if (!cursorManager.IsOpen)
        {
            povcamera.m_HorizontalAxis.m_InputAxisName = "Mouse X";
            povcamera.m_VerticalAxis.m_InputAxisName = "Mouse Y";
        }
        else
        {
            povcamera.m_HorizontalAxis.m_InputAxisValue = 0f;
            povcamera.m_VerticalAxis.m_InputAxisValue = 0f;
            povcamera.m_HorizontalAxis.m_InputAxisName = "";
            povcamera.m_VerticalAxis.m_InputAxisName = "";
        }

        // �Ϲ� MainCamera ��� ��, ĳ���� ȸ�� ���� ��ġ ��Ű�ų� ��� ��Ű�� �ʹ� ��鸮�� ���߱� ������� 
        // Virtual ī�޶� ä���ؼ� Pov�� �����ϰ�  ó�� 
        transform.localRotation = Quaternion.Euler(0, povcamera.m_HorizontalAxis.Value, 0f);
        upperbody.transform.localRotation = Quaternion.Euler(0, povcamera.m_VerticalAxis.Value, 0);

    }
}
