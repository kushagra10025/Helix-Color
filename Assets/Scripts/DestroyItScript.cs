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
    public Shader dissolveShader;
    public float timeDissolve;
    
    private Rigidbody _rigidbody;
    private Vector3 _tempPos;
    private Renderer _meshRenderer;
    
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
            //childObjects.Remove(t);
            //Destroy(t);
            t.tag = "changedObj";
            _meshRenderer = t.GetComponent<MeshRenderer>();
//            if(_meshRenderer.enabled == false)
//                Debug.Log(t.name);

            _meshRenderer.materials[0].shader = dissolveShader;
            DeleteGameObject();
        }
    }

    private void DeleteGameObject()
    {
        foreach (var childObject in childObjects)
        {
            Destroy(childObject.GetComponent<Collider>());
        }
    }
}
