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
    [SerializeField] private float jumpForce = 1000;
    [SerializeField] private float moveForce = 1000;
    [SerializeField] private GameObject bulletPrefab;
    private bool _isTouchGround;
    private bool _isJumping;

    [SerializeField] private LayerMask mask;

    [SerializeField] private float hp = 100;
    [SerializeField] private float maxHp = 100;

    public float speedControl;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
        
        // if (Input.GetKey(KeyCode.LeftArrow) || speedControl <= -4)
        // {
        //     if (Input.GetKey(KeyCode.LeftShift))
        //     {
        //         RunLeft();
        //     }
        //     else
        //     {
        //         WalkLeft();
        //     }
        // }
        // else if (Input.GetKey(KeyCode.RightArrow) || speedControl >= 4)
        // {
        //     if (Input.GetKey(KeyCode.LeftShift))
        //     {
        //         RunRight();
        //     }
        //     else
        //     {
        //         WalkRight();
        //     }
        // }
        // else
        // {
        //     ChangeSpeed(0);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Jump();
        // }
        //
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     Attack();
        // }

        // if (Input.GetKeyUp(KeyCode.A))
        // {
        //     StopAttack();
        // }

        CheckHit();
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
        if (!_isTouchGround && rigidbody2D.velocity.y > 0) return;
        if (_isJumping) return;
        _isJumping = true;
        // rigidbody2D.AddForce(Vector2.up * (jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        Vector2 velocity = rigidbody2D.velocity;
        velocity.y = jumpForce * Time.deltaTime;
        rigidbody2D.velocity = velocity;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool(ANIM_BLOCK, false);
        _isTouchGround = true;
        if (_isJumping) _isJumping = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isTouchGround = false;
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
}
