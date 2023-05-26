using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    private Vector2 _spown_position = default;

    private bool _isRight = default;
    private bool _isLeft = default;

    private float _move_distance = 2;

    protected virtual void Awake()
    {
        SetValue();
    }

    protected override void Update()
    {
        Input();
        base.Update();
    }

    private void SetValue()
    {
        _spown_position = transform.position;
        _isLeft = !_isRight;
    }

    private void Input()
    {
        if (_spown_position.x - transform.position.x > _move_distance && _isLeft)
        {
            _isLeft = false;
            _isRight = true;
        }
        else if (_spown_position.x - transform.position.x < -_move_distance && _isRight)
        {
            _isRight = false;
            _isLeft = true;
        }

        if (_isRight)
        {
            _chara_move_direction = 1;
        }
        else if (_isLeft)
        {
            _chara_move_direction = -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _my_enemy_tag && !_isDeath)
        {
            collision.gameObject.GetComponent<CharacterController>().CharaLifeCalculation(_attack_power);
        }
    }
}
