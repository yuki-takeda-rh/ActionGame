using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance = default;

    public enum Character_id
    {
        Player,
        RedSlime,
        YellowSlime
    }

    public enum GameObject_tag_name
    {
        Ground,
        Token,
        Player,
        Enemy,
    }

    public int _collect_token_count { get; private set; } = default;

    public static GameManager Instance
    {
        get{
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public void GetToken()
    {
        _collect_token_count++;
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void GameClear()
    {

    }
}
