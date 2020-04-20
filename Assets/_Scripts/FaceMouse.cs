using System;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    private Vector3 _mousePos;
    private SpriteRenderer _sRenderer;
    private Pause pause;

    private void Start()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
        pause = FindObjectOfType<Pause>();
    }

    private void Update()
    {
        if (pause.isPaused || GameManager.Instance.gameOver) return;
        _mousePos = Input.mousePosition;
        _mousePos = GameManager.Instance.mainCamera.ScreenToWorldPoint(_mousePos);
        if (_mousePos.x > 1)
        {
            _sRenderer.flipX = false;
        } else if (_mousePos.x < -1)
        {
            _sRenderer.flipX = true;
            
        }
    }
}
