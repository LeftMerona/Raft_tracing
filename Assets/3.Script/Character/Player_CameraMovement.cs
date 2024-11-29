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
        // 좌우 회전은 전체, 상체로 수직만 맞추기
        transform.localRotation = Quaternion.Euler(0, povcamera.m_HorizontalAxis.Value, 0f);
        upperbody.transform.localRotation = Quaternion.Euler(0, povcamera.m_VerticalAxis.Value, 0);


        // 일반 MainCamera 사용 시, 캐릭터 회전 값을 일치 시키거나 상속 시키면 너무 흔들리고 맞추기 어려워서 
        // Virtual 카메라 채용해서 Pov로 원할하게  처리 
    }


}
