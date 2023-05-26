using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    private InputSystem input = default;
    private StageManager stageManager = default;

    private void Awake()
    {
        input = new InputSystem();
        SetValue();
    }

    protected override void Start()
    {
        GameObject.FindWithTag(GameManager.GameObject_tag_name.GameController.ToString()).TryGetComponent(out stageManager);
        base.Start();
    }

    protected override void Update()
    {
        if (transform.position.y <= -5.7f)
        {
            Death();
        }

        Input();

        base.Update();
    }

    private void SetValue()
    {
        _character_id = (int)GameManager.Character_id.Player;
    }

    private void Input()
    {
        _chara_move_direction = input.InGame.Move.ReadValue<float>();
        _isJump = input.InGame.Jump.triggered;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _my_enemy_tag)
        {
            CharacterController col_controller = collision.gameObject.GetComponent<CharacterController>();
            if (!col_controller._isDeath)
            {
                Jump(1.5f);
                col_controller.CharaLifeCalculation(_attack_power);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameManager.GameObject_tag_name.Token.ToString())
        {
            collision.gameObject.SetActive(false);
            stageManager.GetToken();
        }

#if UNITY_EDITOR
        if (collision.gameObject.tag == "GameOver")
        {
            stageManager.GameOver();
        }
        else if (collision.gameObject.tag == "GameClear")
        {
            stageManager.StageClear();
        }
#endif
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        if (_life <= 0)
        {
            stageManager.GameOver();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube((Vector2)transform.position + new Vector2(_chara_move_direction, 0) * 0.8f, new Vector2(0.1f, 1.3f));
    }
}
