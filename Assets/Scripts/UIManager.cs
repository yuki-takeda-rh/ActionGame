using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject FirstPanel = default;
    [SerializeField]
    private GameObject SecondPanel = default;

    [SerializeField]
    private Text text = default;

    private void Update()
    {
        if (text != null)
        {
            text.text = "Token: " + GameManager.Instance._collect_all_token_count.ToString() + "ŒÂ";
        }
    }

    public void SelectStage()
    {
        SecondPanel.SetActive(true);
        FirstPanel.SetActive(false);
    }

    public void ReturnPanel()
    {
        FirstPanel.SetActive(true);
        SecondPanel.SetActive(false);
    }

    public void PushStage1()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void BackTitle()
    {
        SceneManager.LoadSceneAsync("Title");
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
