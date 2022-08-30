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

    [SerializeField] private Transform directionArrow;
    [SerializeField] private Transform bulletStartPosition;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float jumpForce = 1000;
    [SerializeField] private float moveForce = 1000;
    [SerializeField] private GameObject bulletPrefab;
    private bool _isTouchGround;

    [SerializeField] private LayerMask mask;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
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
        else if (Input.GetKey(KeyCode.RightArrow))
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
        else
        {
            ChangeSpeed(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }

        // if (Input.GetKeyUp(KeyCode.A))
        // {
        //     StopAttack();
        // }

        if (rigidbody2D.velocity.magnitude > 0.1f)
        {
            Vector3 rotation = Vector3.zero;
            rotation.z = -Vector2.Angle(rigidbody2D.velocity, Vector2.up) * Mathf.Sign(speed);
            directionArrow.eulerAngles = rotation;
        }

        CheckHit();
    }

    void WalkLeft()
    {
        spriteRenderer.flipX = true;
        ChangeSpeed(-4);
    }

    void WalkRight()
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

    void ChangeSpeed(float speed)
    {
        this.speed = speed;
        Vector2 velocity = rigidbody2D.velocity;
        velocity.x = moveForce * speed * Time.deltaTime;
        rigidbody2D.velocity = velocity;
        anim.SetFloat(ANIM_SPEED, Mathf.Abs(speed));
    }

    void Jump()
    {
        if (!_isTouchGround) return;
        // rigidbody2D.AddForce(Vector2.up * (jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        Vector2 velocity = rigidbody2D.velocity;
        velocity.y = jumpForce * Time.deltaTime;
        rigidbody2D.velocity = velocity;
        anim.SetBool(ANIM_BLOCK, true);
    }

    void Attack()
    {
        // anim.SetBool(ANIM_ATTACK, true);
        GameObject bulletObj = Instantiate(bulletPrefab, bulletStartPosition.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        float direction = spriteRenderer.flipX ? -1 : 1;
        bullet.speed = Mathf.Abs(bullet.speed) * direction;
        bullet.spriteRenderer.flipX = spriteRenderer.flipX;
    }

    // void StopAttack()
    // {
    //     anim.SetBool(ANIM_ATTACK, false);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool(ANIM_BLOCK, false);
        _isTouchGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isTouchGround = false;
    }

    void CheckHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, mask);
        
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }
    }
}