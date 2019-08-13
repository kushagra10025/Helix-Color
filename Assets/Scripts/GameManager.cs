using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public GameObject[] hollowCylinderPatterns;
    public GameObject baseCylinderPrefab;
    public GameObject cylinderPrefab;
    public GameObject playerBall;
    public GameObject lastCylinderPrefab;

    private int _posUpForBaseCylinder = 2;

    private GameObject _mainCylinderObj;
    private Vector3 _playerStartPosition;
    private GameObject _initialCylinder;
    
    [SerializeField] private int lengthForCylinder = 10;
    [SerializeField] private int minGapBetweenObs = 2;
    

    private void Awake()
    {
        if (hollowCylinderPatterns == null)
            return;
        if (baseCylinderPrefab == null)
            return;
    }

    private void Start()
    {
        LevelStartBasics();
    }
    
    #region LevelGen

    private void LevelStartBasics()
    {
        _mainCylinderObj = Instantiate(baseCylinderPrefab) as GameObject;
        _mainCylinderObj.tag = "MainCylinder";
        _initialCylinder = Instantiate(hollowCylinderPatterns[0]);
        _initialCylinder.tag = "InitialCylinder";
        
        for (int i = 1; i <= lengthForCylinder-1; i++)
        {
            CylinderRandomized();
            ObstacleRandomized();
        }
        InitLastCylinder();
    }

    private void InitLastCylinder()
    {
        GameObject lCP = Instantiate(lastCylinderPrefab) as GameObject;
        Vector3 posVec = lCP.GetComponent<Transform>().position;
        posVec.y = _posUpForBaseCylinder;
        lCP.GetComponent<Transform>().position = posVec;
        GameObject pB = Instantiate(playerBall) as GameObject;
        _playerStartPosition = pB.GetComponent<Transform>().position;
        _playerStartPosition.y = posVec.y + 1.0f;
        pB.GetComponent<Transform>().position = _playerStartPosition;

        CameraController.Instance.SetupCmCamera(pB);
        
    }

    private void CylinderRandomized()
    {
        Vector3 temp;
        GameObject go = Instantiate(cylinderPrefab) as GameObject;
        temp = go.GetComponent<Transform>().position;
        temp.y += _posUpForBaseCylinder;
        _posUpForBaseCylinder += 2;
        go.GetComponent<Transform>().SetParent(_mainCylinderObj.transform.GetChild(0).transform);
        go.GetComponent<Transform>().position = temp;
        
    }

    private void ObstacleRandomized()
    {
        Vector3 tempPos,tempRot;
        int randomObs = Random.Range(1, hollowCylinderPatterns.Length);
        GameObject obs = Instantiate(hollowCylinderPatterns[randomObs]) as GameObject;

        tempPos = obs.GetComponent<Transform>().position;
        tempRot = new Vector3(0f,Random.Range(0f,360.0f),0f);
        Quaternion tempRotation = Quaternion.Euler(tempRot);
        obs.GetComponent<Transform>().rotation = tempRotation;
        obs.GetComponent<Transform>().SetParent(_mainCylinderObj.transform.GetChild(1).transform);
        tempPos.y += minGapBetweenObs;
        minGapBetweenObs += 2;
        obs.GetComponent<Transform>().position = tempPos;
    }
    
    #endregion
}
