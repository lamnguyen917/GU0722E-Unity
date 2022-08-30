using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Transform leftPosition;

    [SerializeField] private Transform rightPosition;

    [SerializeField] private Transform platform;

    void Update()
    {
        platform.position =
            Vector3.Lerp(leftPosition.position, rightPosition.position, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}