using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class TargetType : MonoBehaviour
{
    [SerializeField] public Diet diet;
    [SerializeField] private Transform crumbSpawn;
    [SerializeField] private GameObject breadCrumbs;
    [SerializeField] private GameObject fruitCrumbs;
    [SerializeField] private GameObject meatCrumbs;
    [SerializeField] private GameObject junkCrumbs;
    [SerializeField] private GameObject sugarCrumbs;
    
    private TargetGrowth _targetGrowth;

    private void Start()
    {
        _targetGrowth = GetComponent<TargetGrowth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (GameManager.Instance.gameMode)
        {
            case Diet.Meat:
                ProcessMeatEdibles(other);
                break;
            case Diet.Garbage:
                ProcessGarbageEdibles(other);
                break;
            case Diet.Vegetarian:
                ProcessVegetarianEdibles(other);
                break;
            default:
                Debug.LogError("INVALID DIET TYPE SELECTED");
                break;
        }

        PlayEatAnimation();
        SpawnParticles(other.tag);
    }

    private void SpawnParticles(String food)
    {
        switch (food)
        {
            case "Bread":
                Instantiate(breadCrumbs, crumbSpawn.position, Quaternion.identity);
                break;
            case "Fruit":
                Instantiate(fruitCrumbs, crumbSpawn.position, Quaternion.identity);
                break;
            case "Junk":
                Instantiate(junkCrumbs, crumbSpawn.position, Quaternion.identity);
                break;
            case "Meat":
                Instantiate(meatCrumbs, crumbSpawn.position, Quaternion.identity);
                break;
            case "Sugar":
                Instantiate(sugarCrumbs, crumbSpawn.position, Quaternion.identity);
                break;
            
        }
    }

    private void ProcessMeatEdibles(Collider2D edible)
    {
        if (edible.CompareTag("Meat"))
        {
            Grow();
        }
        else
        {
            Shrink();
        }
    }

    private void ProcessGarbageEdibles(Collider2D edible)
    {
        if (edible.CompareTag("Junk") || edible.CompareTag("Sugar"))
        {
            Grow();
        }
        else
        {
            Shrink();
        }
    }
    
    private void ProcessVegetarianEdibles(Collider2D edible)
    {
        if (edible.CompareTag("Fruit") || edible.CompareTag("Bread") || edible.CompareTag("Sugar"))
        {
            Grow();
        }
        else
        {
            Shrink();
        }
    }

    private void PlayEatAnimation()
    {
        GameObject stage = _targetGrowth.ActiveStage();
        if (stage != null)
        {
            GameManager.Instance.audioManager.PlaySound(Sound.OMNOMNOM);
            stage.GetComponent<Animator>().SetTrigger("isEating");
        }
    }

    private void Grow()
    {
        _targetGrowth.Increase();
    }

    private void Shrink()
    {
        _targetGrowth.Decrease();
    }
    
    public enum Diet
    {
        Meat, 
        Vegetarian,
        Garbage
    }
}
