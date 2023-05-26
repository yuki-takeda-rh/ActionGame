using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSystem : MonoBehaviour
{
#if UNITY_EDITOR
    private StageManager stageManager = default;

    private void Start()
    {
        stageManager = GameObject.FindWithTag(GameManager.GameObject_tag_name.GameController.ToString()).GetComponent<StageManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            stageManager.StageClear();
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            stageManager.GameOver();
        }
    }
#endif
}
