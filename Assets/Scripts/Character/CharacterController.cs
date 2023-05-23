using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb = default;
    private Animator anim = default;
    private SpriteRenderer sprite = default;
    private CharacterDataManager dataManager = default;

    protected Vector2 _move_vector = default;

    protected bool _isGround = default;

    protected int _character_id = default;

    //ê≥èÌîªíË----------------------------

    private bool _canAnimation = default;
    private bool _canFlip = default;

    //parameteor--------------------------

    protected float _life = 100;
    protected float _attack_power = 10;
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
        if (GameObject.FindWithTag("GameController").TryGetComponent(out dataManager))
        {
            SetParameteor();
        }
    }

    protected virtual void Update()
    {
        Move();

        if (_canAnimation && _canFlip)
        {
            View();
        }
    }

    private void SetParameteor()
    {
        _life = float.Parse(dataManager._character_datas[_character_id][2]);
        _attack_power = float.Parse(dataManager._character_datas[_character_id][3]);
        _speed = float.Parse(dataManager._character_datas[_character_id][4]);
        _jump_power = float.Parse(dataManager._character_datas[_character_id][5]);
    }

    protected virtual void Move()
    {
        _move_vector.x = _chara_move_direction * _speed;

        if (_isJump && _isGround)
        {
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