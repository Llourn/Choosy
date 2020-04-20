using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public SceneController sceneController;
    public AudioManager audioManager;
    public Camera mainCamera;

    public bool gameOver = false;
    
    [HideInInspector]
    public TargetType.Diet gameMode;

    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        audioManager = FindObjectOfType<AudioManager>();
        mainCamera = FindObjectOfType<Camera>();
        sceneController.LoadStart();
    }


    public void Quit()
    {
        Application.Quit();
    }
    
    
}