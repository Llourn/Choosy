using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClickSound);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.audioManager.PlaySound(Sound.ButtonHover);
    }
    
    private void ButtonClickSound()
    {
        GameManager.Instance.audioManager.PlaySound(Sound.ButtonClick);
    }
}

