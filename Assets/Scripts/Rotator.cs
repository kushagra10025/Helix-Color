using System;
using UnityEngine;

public class Rotator : MonoBehaviour {

    [SerializeField]private float rotationSensitivity = 0f;

    private Vector3 _startPos;
    private Vector3 _lastPoint;
    private float _offset;

    public static Rotator Instance;

    public bool isInputActive = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
//        if (Input.GetMouseButton(0)) 
//        {
//            float horizontal = Input.GetAxis("Mouse X");
//
//            var eulerP = (-Vector3.up * horizontal )* (350.0f * Time.deltaTime);
//
//            transform.Rotate(eulerP, Space.World);
//        }
        
        if (Input.touchCount > 0 && Input.touchCount <=1 && isInputActive)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _lastPoint = touch.position;
                    break;
                case TouchPhase.Moved:
                    _offset = touch.position.x - _lastPoint.x;
                    transform.Rotate(0,_offset * rotationSensitivity * -1,0);

                    _lastPoint = touch.position;
                    break;
                case TouchPhase.Ended:
                    break;
            }
        }
    }
}