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
    private Text all_token_text = default;

    [SerializeField]
    private Text get_token_text = default;

    private void Update()
    {
        if (all_token_text != null)
        {
            all_token_text.text = "All:    " + GameManager.Instance._collect_all_token_count.ToString() + "ŒÂ";
        }

        if (get_token_text != null)
        {
            get_token_text.text = "       +" + GameManager.Instance._collect_all_token_count.ToString() + "ŒÂ";
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
