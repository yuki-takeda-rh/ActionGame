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
        Input();

        base.Update();
    }

    private void SetValue()
    {
        _character_id = (int)GameManager.character_id.Player;
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
