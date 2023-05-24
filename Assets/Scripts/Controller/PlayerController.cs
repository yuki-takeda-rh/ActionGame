using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    private InputSystem input = default;

    private void Awake()
    {
        input = new InputSystem();
        SetValue();
    }

    protected override void Update()
    {
        if (transform.position.y  < -5.7f)
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

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _my_enemy_tag)
        {
            collision.gameObject.GetComponent<CharacterController>().CharaLifeCalculation(_attack_power);
            Jump(0.3f);
        }
            
        base.OnTriggerEnter2D(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameManager.GameObject_tag_name.Token.ToString())
        {
            GameManager.Instance.GetToken();
            collision.gameObject.SetActive(false);
        }
    }
}
