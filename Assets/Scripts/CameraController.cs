using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    private CinemachineVirtualCamera _virtualCamera;

    public static CameraController Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        //DontDestroyOnLoad(gameObject);
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
        cFt.m_LookaheadSmoothing = 3.0f;
        
        //Height & Y Axis Settings
        
        cFt.m_SoftZoneHeight = 0.5f;
        cFt.m_ScreenY = 0.65f;
        cFt.m_YDamping = 0f;//To make the camera immediately follow the ball upon falling
        cFt.m_DeadZoneHeight = 0.24f;

        // Width & X Axis Settings
        
        cFt.m_SoftZoneWidth = 0.5f;
        cFt.m_XDamping = 0f;
        cFt.m_DeadZoneWidth = 0.17f;
        
        // z Axis Values

        cFt.m_ZDamping = 3.5f; // To make smooth camera movement and make the camera from moving too far

        //Camera.main.GetComponent<Transform>().SetParent(playerBall.transform);

    }
}
