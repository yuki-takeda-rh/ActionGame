using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance = default;

    public enum character_id
    {
        Player,
        RedSlime,
        YellowSlime
    }

    public static GameManager Instance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }
        return _instance;
    }

    public void GameOver()
    {

    }

    public void GameClear()
    {

    }
}
