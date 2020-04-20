using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [HideInInspector]
    public bool isPaused = false;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.gameOver)
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        } else if (!isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void OnMainMenuButtonPress()
    {
        isPaused = false;
        Time.timeScale = 1;
        GameManager.Instance.sceneController.LoadStart();
    }

    public void OnExitButtonPress()
    {
        Application.Quit();
    }
}
