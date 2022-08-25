using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private bool isTrigger;

    private void Update()
    {
        if (isTrigger)
        {
            var pos = transform.position;
            pos.y += Time.deltaTime;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Is trigger enter");
        isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Is trigger stay");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Is trigger exit");
        isTrigger = false;
    }
}