/*
** Unity Script UIScript
** By		: 
** Dated	:
** Desc		:
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static UIScript Instance;

    #region Public Variables
    #endregion

    #region Private Variables
    #endregion

    #region Serializeable Private Variables
    #endregion

    #region Hide Public Variables
    #endregion

    #region Unity Methods
    private void Awake()
    {
        
        if(Instance == null)
        	Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    #endregion

    #region Private Methods

    public void LoadLevel(int Index)
    {
        SceneManager.LoadScene(Index);
        Rotator.Instance.isInputActive = true;
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
