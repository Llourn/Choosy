using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDiet : MonoBehaviour
{
    [SerializeField] private float timeToDisplay;
    [SerializeField] private GameObject meatDiet;
    [SerializeField] private GameObject junkDiet;
    [SerializeField] private GameObject vegDiet;

    private float _timer;
    private bool _gameStarted = false;
    private void Start()
    {
        _gameStarted = false;
        switch (GameManager.Instance.gameMode)
        {
            case TargetType.Diet.Meat:
                meatDiet.SetActive(true);
                break;
            
            case TargetType.Diet.Garbage:
                junkDiet.SetActive(true);
                break;
            
            case TargetType.Diet.Vegetarian:
                vegDiet.SetActive(true);
                break;

            default:
                Debug.LogError("GAME MODE NOT SELECTED");
                break;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < timeToDisplay || _gameStarted) return;
        
        meatDiet.SetActive(false);
        junkDiet.SetActive(false);
        vegDiet.SetActive(false);
        _gameStarted = true;
    }
}
