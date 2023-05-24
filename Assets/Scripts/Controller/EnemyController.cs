using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    private Vector2 _spown_position = default;

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
    }

    private void Input()
    {
        if (transform.position.x - _spown_position.x > _move_distance)
        {
            _chara_move_direction = -1;
        }
        else if (transform.position.x - _spown_position.x <= -_move_distance)
        {
            _chara_move_direction = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _my_enemy_tag)
        {
            collision.gameObject.GetComponent<CharacterController>().CharaLifeCalculation(_attack_power);
        }
    }
}
