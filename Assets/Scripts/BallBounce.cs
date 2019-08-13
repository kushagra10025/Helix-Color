using System;
using UnityEngine;

public class BallBounce : MonoBehaviour {

    public Rigidbody rb;
    public float impulseForce = 5f;

    private Vector3 _startPos;
    public int perfectPass = 0;
    private bool _ignoreNextCollision;
    public bool isSuperSpeedActive;
    public bool canDie = true;
    public float forceMultiplier = 7.0f;
    
    private int _prevCollider = 0;

    public static BallBounce Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        //canDie = true;
        
        _startPos = transform.position;
    }



    private void OnCollisionEnter(Collision other)
    {
        if (_ignoreNextCollision)
            return;
        if (isSuperSpeedActive && !canDie)
        {
            Collider childCollider = other.contacts[0].otherCollider;
            
            if ((childCollider.gameObject.CompareTag("LastOne")))
            {
                //Debug.Log("Has Reached Last One!");
                Destroy(other.transform.parent.gameObject);
            }
            else
            {
                //Debug.Log("Has Not Reached Last One!");
                Destroy(other.gameObject);
            }

        }

        rb.velocity = Vector3.zero; // Remove velocity to not make the ball jump higher after falling done a greater distance
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);



        // Safety check
        _ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);

        // Handling super speed
        _prevCollider = 1;
        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;
        
        if (_prevCollider == 1 && other.gameObject.CompareTag("blankObj"))
        {
            _prevCollider = 0;
        }
        perfectPass++;
    }

    private void Update()
    {
        //Debug.Log("Coll Stat - "+ _prevCollider + "      PerfectPass - "+ perfectPass);
        // activate super speed
        if (perfectPass >= 3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            canDie = false;
            rb.AddForce(Vector3.down * forceMultiplier, ForceMode.Impulse);
        }

        if (perfectPass < 3)
        {
            canDie = true;
        }

    }

    public void ResetBall()
    {
        transform.position = _startPos;
    }

    private void AllowCollision()
    {
        _ignoreNextCollision = false;
    }


}
