using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x;
        transform.position = pos;
    }
}