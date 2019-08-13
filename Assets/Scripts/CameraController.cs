﻿using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    private CinemachineVirtualCamera _virtualCamera;

    public static CameraController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    public void SetupCmCamera(GameObject playerBall)
    {
        if (Camera.main == null)
            return;
        
        if (_virtualCamera == null)
            _virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
        
        _virtualCamera.Follow = playerBall.transform;
        _virtualCamera.m_Lens.FieldOfView = 28f;
        _virtualCamera.AddCinemachineComponent<CinemachineFramingTransposer>();
        var cFt = _virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        cFt.m_CameraDistance = 13.5f;
        
        //Height & Y Axis Settings
        
        cFt.m_SoftZoneHeight = 0.5f;
        cFt.m_ScreenY = 0.65f;
        cFt.m_YDamping = 0f;
        cFt.m_DeadZoneHeight = 0.20f;

        // Width & X Axis Settings
        
        cFt.m_SoftZoneWidth = 0.5f;
        cFt.m_DeadZoneWidth = 0.15f;
        
        // z Axis Values

        cFt.m_ZDamping = 10f;

        //Camera.main.GetComponent<Transform>().SetParent(playerBall.transform);

    }
}
