using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class DestroyItScript : MonoBehaviour
{
    public static DestroyItScript Instance;
    public List<GameObject> childObjects;
    public Shader dissolveShader;
    
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
        if (obj.CompareTag("InitialCylinder"))
        {
            //Debug.Log("Last");
            return;
        }
        
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            childObjects.Add(obj.transform.GetChild(i).gameObject);
        }
    }

    public void DestroyIt()
    {
        foreach (var t in childObjects)
        {
            t.tag = "changedObj";
            _meshRenderer = t.GetComponent<MeshRenderer>();

            var matA = _meshRenderer.materials;
            matA[0].shader = dissolveShader;
            
            matA[0].SetFloat("_TriggerTime",Time.timeSinceLevelLoad);
            DeleteGameObject();
            StartCoroutine(ResetShaderTrigger(matA[0]));
        }
    }

    private void DeleteGameObject()
    {
        foreach (var childObject in childObjects)
        {
            Destroy(childObject.GetComponent<Collider>());
        }
    }

    private IEnumerator ResetShaderTrigger(Material mat)
    {
        yield return new WaitForSeconds(5);
        mat.SetFloat("_TriggerTime",999999);
    }
}
