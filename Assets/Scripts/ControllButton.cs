using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllButton : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float speed = 4;

    public void OnMouseDown()
    {
        Debug.Log("on mouse down");
        player.speedControl = speed;
        Debug.Log(player.speedControl);
    }

    public void OnMouseUp()
    {
        Debug.Log("on mouse up");
        player.speedControl = 0;
        Debug.Log(player.speedControl);
    }
}