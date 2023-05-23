using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb = default;
    private Animator anim = default;
    private SpriteRenderer sprite = default;

    protected Vector2 _move_vector = default;

    protected bool _isGround = default;

    //ê≥èÌîªíË----------------------------

    private bool _canAnimation = default;
    private bool _canFlip = default;

    //parameteor--------------------------

    protected float _speed = 10;
    protected float _jump_power = 20;

    //geter-------------------------------
    public Vector3 _character_vector
    {
        get { return _move_vector; }
    }

    //input-------------------------------
    protected float _chara_move_direction = default;
    protected bool _isJump = default;

    private void Start()
    {
        TryGetComponent(out rb);
        _canAnimation = TryGetComponent(out anim);
        _canFlip = TryGetComponent(out sprite);
    }

    protected virtual void Update()
    {
        Move();

        if (_canAnimation && _canFlip)
        {
            View();
        }
    }

    protected virtual void Move()
    {
        _move_vector.x = _chara_move_direction * _speed;

        if (_isJump && _isGround)
        {
            Debug.Log(_isJump);
            Jump();
        }
        _move_vector.y = rb.velocity.y;

        rb.velocity = _move_vector;
    }

    protected virtual void Jump()
    {
        rb.AddForce(Vector2.up * _jump_power, ForceMode2D.Impulse);
    }

    protected virtual void View()
    {
        sprite.flipX = rb.velocity.x < 0;
        anim.SetFloat("velocityX", rb.velocity.x);
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("isMoving", rb.velocity != Vector2.zero);
        anim.SetBool("isOnGround", _isGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
}