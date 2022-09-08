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

    public void SetHp(float amount)
    {
        hpIndicator.fillAmount = amount;
    }

    private void Update()
    {
        string s = "";

        if (Input.GetKey(KeyCode.LeftArrow)) s += "← ";
        if (Input.GetKey(KeyCode.RightArrow)) s += "→ ";
        if (Input.GetKey(KeyCode.A)) s += "A ";
        if (Input.GetKey(KeyCode.D)) s += "D";
        if (Input.GetMouseButton(0)) s += "M0";
        inputText.text = s;

        axis.text = $"{Input.GetAxis("Mouse X")}; {Input.GetAxis("Mouse Y")}";
    }
}