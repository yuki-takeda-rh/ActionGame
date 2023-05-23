using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    private Vector2 _spown_position = default;

    private float _move_distance = 2;

    private void Awake()
    {
        _spown_position = transform.position;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void Input()
    {
        if (transform.position.x - _spown_position.x > _move_distance)
        {
            _chara_move_direction = -1;
        }
    }
}
