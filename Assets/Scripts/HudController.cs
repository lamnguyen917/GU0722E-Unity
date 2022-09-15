using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public static HudController Instance;

    [SerializeField] private Image hpIndicator;
    [SerializeField] private TMP_Text inputText;
    [SerializeField] private TMP_Text axis;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        inputText.SetText(PlayerPrefs.GetString("coin_trigger", "NONE"));
    }

    public void SetHp(float amount)
    {
        hpIndicator.fillAmount = amount;
    }

    public void SetCoin(int amount)
    {
    }

    private void Update()
    {
        axis.SetText($"Coins: {GameManager.Instance.coins}");
        
        inputText.SetText(GameManager.Instance.GetEmployeeString());
    }

    public void LoadJson(string content)
    {
        inputText.SetText(content);
    }
}