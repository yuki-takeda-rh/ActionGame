using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb = default;
    private SpriteRenderer sprite = default;
    private CharacterDataManager dataManager = default;
    protected Animator anim = default;

    protected Vector2 _move_vector = default;

    protected bool _isGround = default;
    public bool _isDeath { get; protected set; } = default;

    protected int _character_id = default;

    protected string _my_enemy_tag = default;

    private const int _groundlayer = 1 << 8;

    protected Vector2 _height_scale = default;

    //³í”»’è----------------------------

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

    protected virtual void Start()
    {
        _height_scale = new Vector2(0.1f, transform.localScale.y -0.5f);
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
        Ground();

        Move();

        if (_canAnimation && _canFlip)
        {
            View();
        }
    }

    // TODO:‚à‚Á‚Æ‚«‚ê‚¢‚ÉŽÀ‘•
    private void SetParameteor()
    {
        if (_character_id == 0)
        {
            _my_enemy_tag = GameManager.GameObject_tag_name.Enemy.ToString();
        }
        else
        {
            _my_enemy_tag = GameManager.GameObject_tag_name.Player.ToString();
        }
        _life = float.Parse(dataManager._character_datas[_character_id][2]);
        _attack_power = float.Parse(dataManager._character_datas[_character_id][3]);
        _speed = float.Parse(dataManager._character_datas[_character_id][4]);
        _jump_power = float.Parse(dataManager._character_datas[_character_id][5]);
    }

    // TODO:Boxcast‚ÅŽÀ‘•
    private void Ground()
    {
        _isGround = Physics2D.BoxCast(transform.position, new Vector2(0.8f, 0.1f), 0, Vector2.down, 0.8f, _groundlayer);
    }

    protected virtual void Move()
    {
        if (!Physics2D.BoxCast(transform.position, _height_scale, 0, new Vector2(_chara_move_direction, 0), 0.8f, _groundlayer))
        {
            _move_vector.x = _chara_move_direction * _speed;
        }
        else
        {
            _move_vector.x = 0;
        }

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

    protected virtual void Jump(float magnification)
    {
        rb.AddForce(Vector2.up * _jump_power * magnification, ForceMode2D.Impulse);
    }

    public void CharaLifeCalculation(float damage)
    {
        if (!_isDeath)
        {
            _life -= damage;
            anim.SetTrigger("hurt");
            if (_life <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        _isDeath = true;
        anim.SetTrigger("IsDeath");

    }

    // TODO:CharacterAnimationController‚ÅŽÀ‘•
    protected virtual void View()
    {
        sprite.flipX = rb.velocity.x < 0;
        anim.SetFloat("velocityX", _chara_move_direction);
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("isMoving", rb.velocity != Vector2.zero || _chara_move_direction != 0);
        anim.SetBool("isOnGround", _isGround);
    }
}