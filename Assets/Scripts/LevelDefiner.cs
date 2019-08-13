using UnityEngine;

public class LevelDefiner : MonoBehaviour
{
    public static LevelDefiner Instance;

    [SerializeField] private Color obstacleMaterial = Color.white;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other == null)
            return;
        
        Collider childCollider = other.contacts[0].otherCollider;
        

        MeshRenderer mats = childCollider.gameObject.GetComponent<MeshRenderer>();
        
        Color matColor = mats.materials[0].color;
        
        if( Mathf.Approximately(matColor.r,obstacleMaterial.r) &&
            Mathf.Approximately(matColor.g,obstacleMaterial.g) &&
            Mathf.Approximately(matColor.b,obstacleMaterial.b) &&
            Mathf.Approximately(matColor.a,obstacleMaterial.a))
        {
            //Death Handler
            UIHandler.Instance.PlaceholderTextToPrint("You Died!");
            //UIHandler.Instance.restartGameButton.SetActive(true);
            UIHandler.Instance.PauseGame();
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("InitialCylinder"))
        {
            //Level Finish Handler
            UIHandler.Instance.PlaceholderTextToPrint("You Passed!");
            UIHandler.Instance.PauseGame();
            
            Destroy(gameObject);
        }
        
       
        
    }
}
