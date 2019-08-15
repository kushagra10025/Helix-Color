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
    public Material dissolveShader;
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
            _meshRenderer = t.GetComponent<Renderer>();
//            if(_meshRenderer.enabled == false)
//                Debug.Log(t.name);

            _meshRenderer.material = dissolveShader;
            StartCoroutine("DissolveValue", _meshRenderer);
            DeleteGameObject();
        }
    }

    private void DeleteGameObject()
    {
        if (Mathf.Approximately(dissolveShader.GetFloat("_DissolveValue"),-1f))
        {
            foreach (var childObject in childObjects)
            {
                Destroy(childObject.GetComponent<Collider>());
            }
        }
    }

    IEnumerator DissolveValue(Renderer mR)
    {
        mR.material.SetFloat("_DissolveValue",Mathf.Lerp(1.0f,-1.0f,timeDissolve));
        yield return new WaitForSeconds(timeDissolve);
    }
}
