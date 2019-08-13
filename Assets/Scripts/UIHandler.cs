using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance;

    [SerializeField]private Text placeholderText = null;
    public GameObject restartGameButton;
    public GameObject panelObject;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        if(restartGameButton == null)
            return;
    }

    public void PlaceholderTextToPrint(string textToPrint)
    {
        placeholderText.text = textToPrint;
        placeholderText.gameObject.SetActive(true);
    }

    public void RestartLevel(int levelIndex)
    {
        Time.timeScale = 1.0f;
        Rotator.Instance.isInputActive = true;
        SceneManager.LoadScene(levelIndex);
    }

    public void PauseGame()
    {
        restartGameButton.SetActive(true);
        panelObject.SetActive(true);
        Time.timeScale = 0f;
        Rotator.Instance.isInputActive = false;
    }
}
