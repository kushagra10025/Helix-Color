using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItScript : MonoBehaviour
{
    public static DestroyItScript Instance;
    public float explosionForce = 10f;
    public float explosionRadius = 10f;
    public List<GameObject> childObjects;

    private Rigidbody _rigidbody;
   
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        //AddChildToList();
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
        foreach (var obj in childObjects)
        {
            if (obj.GetComponent<Rigidbody>() == null)
                obj.AddComponent<Rigidbody>();

            _rigidbody = obj.GetComponent<Rigidbody>();
            _rigidbody.AddExplosionForce(explosionForce,gameObject.transform.position,explosionRadius);
            
        }

        for (int i = 0; i < childObjects.Count; i++)
        {
            childObjects.RemoveAt(i);
        }
    }
}
