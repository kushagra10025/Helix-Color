using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class DestroyItScript : MonoBehaviour
{
    public static DestroyItScript Instance;
    public float explosionForce = 10f;
    public float explosionRadius = 100f;
    public List<GameObject> childObjects;

    private Rigidbody _rigidbody;
    private Vector3 _tempPos;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        //AddChildToList();
    }

    private void Start()
    {
        //DestroyIt();
    }

    public void AddChildToList(GameObject obj)
    {
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            childObjects.Add(obj.transform.GetChild(i).gameObject);
        }
    }

    public void DestroyIt()
    {
        foreach (var t in childObjects)
        {
            Debug.Log(t.name);
            childObjects.Remove(t);
            Destroy(t);
        }
    }
}
