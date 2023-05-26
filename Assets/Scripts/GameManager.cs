using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance = default;
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
        GameController
    }

    public int _collect_all_token_count { get; private set; } = default;

    public int _last_collect_token_count { get; private set; } = default;

    public void AddToken(int stage_collect_coin)
    {
        _collect_all_token_count += stage_collect_coin;
        Debug.Log(_collect_all_token_count);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void GameClear(int token_count)
    {
        Debug.Log("GameClear");
        AddToken(token_count);
        _last_collect_token_count = token_count;
    }
}