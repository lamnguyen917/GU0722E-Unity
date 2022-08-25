using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float jumpForce = 1000;
    [SerializeField] private float moveForce = 1000;

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

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
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
        anim.SetFloat("speed", Mathf.Abs(speed));
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // rigidbody2D.AddForce(Vector2.right * (speed * Time.deltaTime), ForceMode2D.Force);
    }

    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * (jumpForce * Time.deltaTime), ForceMode2D.Force);
        anim.SetBool("isAttack", true);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetBool("isAttack", false);
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     Debug.Log("Is trigger stay");
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     anim.SetBool("isAttack", true);
    // }
}