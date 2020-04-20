using System;
using UnityEngine;

public class Edible : MonoBehaviour
{
    [SerializeField] private int numberOfHitsUntilExpire;
    private int _hitCounter = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _hitCounter++;
        if(_hitCounter >= numberOfHitsUntilExpire) Destroy(gameObject);
    }
}
