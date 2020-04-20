using System;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float throwingTopSpeed;
    private float _startPosY;
    private float _startPosX;
    private Vector2 _positionOffset;
    private Vector3 _mousePos;
    private bool _isBeingGrabbed = false;
    private Vector3 _velocity;
    private Vector3 _lastMousePosition;
    private Vector3 _mouseDelta;
    private Rigidbody2D _rbody;

    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isBeingGrabbed)
        {
            _rbody.velocity = Vector2.zero;
            _mousePos = Input.mousePosition;
            _mousePos = GameManager.Instance.mainCamera.ScreenToWorldPoint(_mousePos);
            Vector3 targetPos = new Vector3(_mousePos.x - _startPosX, _mousePos.y - _startPosY, transform.position.z);
            gameObject.transform.localPosition = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothSpeed);
        }
    }

    private void FixedUpdate()
    {
        CalculateMouseDelta();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Input.mousePosition;
            _mousePos = GameManager.Instance.mainCamera.ScreenToWorldPoint(_mousePos);
            
            _startPosX = _mousePos.x - transform.localPosition.x;
            _startPosY = _mousePos.y - transform.localPosition.y;
            _isBeingGrabbed = true;
            CalculateMouseDelta();
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _rbody.AddForce(_mouseDelta * throwingTopSpeed, ForceMode2D.Force);
            _isBeingGrabbed = false;
        }
    }

    private void CalculateMouseDelta()
    {
        _mouseDelta = _mousePos - _lastMousePosition;
        _lastMousePosition = _mousePos;

    }

}
