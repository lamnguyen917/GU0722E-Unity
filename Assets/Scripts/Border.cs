using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Bạn đã va chạm với đối tượng {other.transform.name}");
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log($"Bạn đang va chạm với đối tượng {other.transform.name}");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log($"Bạn không còn va chạm với đối tượng {other.transform.name}");
    }
}