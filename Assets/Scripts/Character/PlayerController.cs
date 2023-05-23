using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    private InputSystem input = default;

    [SerializeField]
    private Vector2 _player_scale = default;
    [SerializeField]
    private float _player_tall;

    private void Awake()
    {
        input = new InputSystem();
    }

    protected override void Update()
    {
        Input();

        base.Update();
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
}
