using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenCount : MonoBehaviour
{
    private StageManager stageManager = default;

    [SerializeField]
    private TextMeshProUGUI token_text = default;

    private void Start()
    {
        GameObject.FindWithTag(GameManager.GameObject_tag_name.GameController.ToString()).TryGetComponent(out stageManager);
    }

    private void FixedUpdate()
    {
        token_text.text = stageManager.Get_Stage_Token.ToString();
    }
}
