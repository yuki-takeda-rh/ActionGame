using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    private int _stage_token = default;
    public int Get_Stage_Token
    {
        get { return _stage_token; }
    }

    public void GameOver()
    {
        GameManager.Instance.GameOver();
        SceneManager.LoadSceneAsync("Title");
    }

    public void StageClear()
    {
        GameManager.Instance.GameClear(_stage_token);
        SceneManager.LoadSceneAsync("Result");
    }

    public void GetToken()
    {
        _stage_token++;
    }
}
