using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ANIM_SPEED = "speed";
    private const string ANIM_BLOCK = "isBlock";
    private const string ANIM_JUMP = "isJump";
    private const string ANIM_ATTACK = "isAttack";

    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Vector2 jumpForce;
    [SerializeField] private float moveForce = 1000;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxJump = 1;

    private bool _isTouchGround;
    private bool _isJumping;

    [SerializeField] private LayerMask mask;

    [SerializeField] private float hp = 100;
    [SerializeField] private float maxHp = 100;

    public float speedControl;

    [SerializeField] private AudioClip runSfx;
    [SerializeField] private AudioClip jumpSfx;
    [SerializeField] private AudioSource source;


    void Start()
    {
    }

    void Update()
    {
        PlayRunningSfx();
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                RunLeft();
            }
            else
            {
                WalkLeft();
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                RunRight();
            }
            else
            {
                WalkRight();
            }
        }

        if (Input.GetAxis("Fire1") > 0)
        {
            Attack();
        }

        if (Input.GetAxis("Jump") > 0 && _isTouchGround)
        {
            Jump();
            source.clip = jumpSfx;
            source.loop = false;
            source.Play();
        }

        CheckHit();
    }

    void PlayRunningSfx()
    {
        if (_isJumping) return;
        if (Input.GetAxis("Horizontal") == 0)
        {
            source.Stop();
            return;
        }

        // if (source.clip == runSfx && !source.isPlaying) return;
        source.clip = runSfx;
        source.loop = true;
        source.Play();
    }

    public void WalkLeft()
    {
        spriteRenderer.flipX = true;
        ChangeSpeed(-4);
    }

    public void WalkRight()
    {
        spriteRenderer.flipX = false;
        ChangeSpeed(4);
    }

    void RunLeft()
    {
        spriteRenderer.flipX = true;
        ChangeSpeed(-10);
    }

    void RunRight()
    {
        spriteRenderer.flipX = false;
        ChangeSpeed(10);
    }

    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = moveForce * speed * Time.deltaTime;
        rigidbody2D.velocity = velocity;
        anim.SetFloat(ANIM_SPEED, Mathf.Abs(speed));
    }

    void Jump()
    {
        _isJumping = true;
        _isTouchGround = false;
        rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
        anim.SetBool(ANIM_BLOCK, true);
    }

    public void Attack()
    {
        // anim.SetBool(ANIM_ATTACK, true);
        GameObject bulletObj = Instantiate(bulletPrefab, bulletStartPosition.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        float direction = spriteRenderer.flipX ? -1 : 1;
        bullet.speed = Mathf.Abs(bullet.speed) * direction;
        bullet.spriteRenderer.flipX = spriteRenderer.flipX;
    }

    void CheckHit()
    {
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, mask);
        //
        // if (hit.collider != null)
        // {
        //     Debug.Log(hit.collider.name);
        // }
    }

    public void Damage(float damage)
    {
        hp -= damage;
        float amount = Mathf.Max(hp / maxHp, 0);
        HudController.Instance.SetHp(amount);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isTouchGround = true;
        }
    }
}