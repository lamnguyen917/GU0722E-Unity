using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.coins++;
            PlayerPrefs.SetInt("coins", GameManager.Instance.coins);
        }

        PlayerPrefs.SetString("coin_trigger", col.name);
    }
}