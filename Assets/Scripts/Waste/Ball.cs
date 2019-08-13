using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This fucking script doesn't work so please do something*/

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _startPos = Vector3.zero;


    //public bool isSuperSpeedActive;
    public float impulseForce = 3.5f;


    private void Awake()
    {
        if (_rb == null)
            _rb = gameObject.GetComponent<Rigidbody>();

        _startPos = gameObject.transform.position;
    }

//    private void Update()
//    { 
//        if (!isSuperSpeedActive)
//        {
//            isSuperSpeedActive = true;
//            _rb.AddForce(Vector3.down * impulseForce,ForceMode.Impulse);
//        }
//    }

    private void OnCollisionEnter(Collision other)
    {
        if (other == null)
            return;
        
        _rb.velocity = Vector3.zero;
        _rb.AddForce(Vector3.up*impulseForce , ForceMode.Impulse);


        //isSuperSpeedActive = false;
        //check for multiple passes and ignore collision..
        //check death parameter
        //add super speed parameter
    }
}
