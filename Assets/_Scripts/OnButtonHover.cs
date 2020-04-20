using UnityEngine;
using UnityEngine.EventSystems;

public class OnButtonHover : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.audioManager.PlaySound(Sound.ButtonHover);
    }

}
