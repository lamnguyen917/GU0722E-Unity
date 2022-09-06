using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public static HudController Instance;
    
    [SerializeField] private Image hpIndicator;

    private void Awake()
    {
        Instance = this;
    }

    public void SetHp(float amount)
    {
        hpIndicator.fillAmount = amount;
    }
}
