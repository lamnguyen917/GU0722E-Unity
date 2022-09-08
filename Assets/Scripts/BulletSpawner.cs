using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private float _next = 4;
    private float _timer = 0;

    private void Update()
    {
        if (_timer < 0)
        {
            _timer = _next;
            _next = Random.Range(3f, 5f);
            Shoot();
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }


    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullet.speed = Mathf.Abs(bullet.speed) * -1;
        bullet.spriteRenderer.flipX = true;
    }
}
