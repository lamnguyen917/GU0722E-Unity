using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject hudMenu;

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        hudMenu.SetActive(false);
    }
}