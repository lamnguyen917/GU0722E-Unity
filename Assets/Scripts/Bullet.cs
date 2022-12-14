using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public SpriteRenderer spriteRenderer;
    [SerializeField] protected float damage = 10;

    private void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }
}