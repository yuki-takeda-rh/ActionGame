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

    protected override void OnTriggerEnter2D(Collider2D collision)
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

    private void OnEnable()
    {
        input.Enable();
    }

    [SerializeField]
    Vector2 a;
    [SerializeField]
    Vector2 b;
    [SerializeField]
    float c;
    [SerializeField]
    float d;

    private void OnDrawGizmos()
    {
        bool result = Physics2D.BoxCast(transform.position, a, c, _character_vector / _speed, d);
        Debug.Log(result);
        Gizmos.DrawWireCube(transform.position + _character_vector / _speed * d, a);
    }
}
