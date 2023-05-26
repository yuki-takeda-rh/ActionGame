using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{
    private Animator anim = default;
    private StageManager stageManager = default;

    private bool _isCollect = default;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        stageManager = GameObject.FindWithTag(GameManager.GameObject_tag_name.GameController.ToString()).GetComponent<StageManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == GameManager.GameObject_tag_name.Player.ToString())
        {
            _isCollect = true;
            anim.SetTrigger("isCollect");
        }
    }

    private void OnDisable()
    {
        if (_isCollect)
        {
            stageManager.GetToken();
        }
    }
}
