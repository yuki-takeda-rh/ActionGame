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
            stageManager.GameOver();
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
                Jump(0.8f);
                col_controller.CharaLifeCalculation(_attack_power);
            }
        }

        if (collision.gameObject.tag == "GameOver")
        {
            stageManager.GameOver();
        }
        else if (collision.gameObject.tag == "GameClear")
        {
            input.Disable();
            anim.SetTrigger("victory");
        }
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
}
