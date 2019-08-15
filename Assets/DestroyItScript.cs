using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyItScript : MonoBehaviour
{
    public static DestroyItScript Instance;
    public float explosionForce = 10f;
    public float explosionRadius = 100f;
    public List<GameObject> childObjects;

    private Rigidbody _rigidbody;
   
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
            Destroy(t);
        }


        for (var i = 0; i < childObjects.Count; i++)
        {
            childObjects.RemoveAt(i);
        }
    }
}
