using System;
using UnityEngine;

public class BallBounce : MonoBehaviour {

    //Public Variables
    public Rigidbody rb;
    public float impulseForce = 5f;
    public int perfectPass = 0;
    public bool isSuperSpeedActive;
    public bool canDie = true;
    public float forceMultiplier = 7.0f;
    
    //Private Variables
    private Vector3 _startPos;
    private bool _ignoreNextCollision;
    private int _prevCollider = 0;
    private Animator _animator;
    
    public static BallBounce Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        //canDie = true;
        
        _startPos = transform.position;
        _animator = gameObject.GetComponent<Animator>();
    }



    private void OnCollisionEnter(Collision other)
    {
        if (_ignoreNextCollision)
            return;
        if (isSuperSpeedActive && !canDie)
        {
            Collider childCollider = other.contacts[0].otherCollider;
            DestroyItScript.Instance.AddChildToList(other.gameObject);

            if (!(childCollider.gameObject.CompareTag("LastOne")))
            {
                DestroyItScript.Instance.DestroyIt();
            }

        }

        rb.velocity = Vector3.zero; // Remove velocity to not make the ball jump higher after falling done a greater distance
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);



        // Safety check
        _ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);

        // Handling super speed
        isSuperSpeedActive = false;
        _prevCollider = 1;
        perfectPass = 0;
        //canDie = true;
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
            _animator.SetBool("isInAir",true);
            rb.AddForce(Vector3.down * forceMultiplier, ForceMode.Impulse);
        }
        else if (perfectPass < 3 && !isSuperSpeedActive)
        {
            canDie = true;
            _animator.SetBool("isInAir",false);
        }
        else
        {
            canDie = false;
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
