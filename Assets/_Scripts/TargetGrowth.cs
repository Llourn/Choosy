using System;
using UnityEngine;
using UnityEngine.UI;

public class TargetGrowth : MonoBehaviour
{
    [SerializeField] private Slider growthBar;
    [SerializeField] private GameObject slimeStage1; 
    [SerializeField] private GameObject slimeStage2; 
    [SerializeField] private GameObject slimeStage3; 
    [SerializeField] private GameObject slimeWin; 
    [SerializeField] private GameObject slimeStageDead;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject youWinScreen;
    
    
    private int _growth = 5;
    private Animator _slime1Animator;
    private Animator _slime2Animator;
    private Animator _slime3Animator;
    
    private void Start()
    {
        CheckSlimeStage();
        GrowthBarColor();
        _slime1Animator = slimeStage1.GetComponent<Animator>();
        _slime2Animator = slimeStage2.GetComponent<Animator>();
        _slime3Animator = slimeStage3.GetComponent<Animator>();
    }

    public void Increase()
    {
        _growth += 5;
        if (_growth > 100) _growth = 100;
        growthBar.value = _growth;
        GrowthBarColor();
        CheckSlimeStage();
    }

    public void Decrease()
    {
        _growth -= 5;
        if (_growth < 0) _growth = 0;
        growthBar.value = _growth;
        GrowthBarColor();
        CheckSlimeStage();
    }

    public GameObject ActiveStage()
    {
        if (slimeStage1.activeSelf) return slimeStage1;
        if (slimeStage2.activeSelf) return slimeStage2;
        if (slimeStage3.activeSelf) return slimeStage3;

        return null;
    }

    private void CheckSlimeStage()
    {
        if (_growth == 100)
        {
            GameManager.Instance.gameOver = true;
            youWinScreen.SetActive(true);
            slimeStage1.SetActive(false);
            slimeStage2.SetActive(false);
            slimeStageDead.SetActive(false);
            slimeStage3.SetActive(false);
            slimeWin.SetActive(true);
            return;
        }
        
        if (_growth > 60)
        {
            if (slimeStage3.activeSelf) return;
            slimeStage1.SetActive(false);
            slimeStage2.SetActive(false);
            slimeStageDead.SetActive(false);
            slimeStage3.SetActive(true);

        } else if (_growth > 30)
        {
            if (slimeStage2.activeSelf) return;
            slimeStage1.SetActive(false);
            slimeStage3.SetActive(false);
            slimeStageDead.SetActive(false);
            slimeStage2.SetActive(true);
        } else if (_growth > 0)
        {
            if (slimeStage1.activeSelf) return;
            slimeStage2.SetActive(false);
            slimeStage3.SetActive(false);
            slimeStageDead.SetActive(false);
            slimeStage1.SetActive(true);

        } else if(_growth == 0)
        {
            gameOverScreen.SetActive(true);
            GameManager.Instance.gameOver = true;
            slimeStage2.SetActive(false);
            slimeStage3.SetActive(false);
            slimeStage1.SetActive(false);
            slimeStageDead.SetActive(true);
        }
    }

    private void GrowthBarColor()
    {
        growthBar.fillRect.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, (_growth / 100f));
    }
    
}
