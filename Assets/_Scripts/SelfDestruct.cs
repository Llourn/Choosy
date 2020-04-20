using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timeUntilDestruction;

    private void Start()
    {
        Destroy(gameObject, timeUntilDestruction);
    }
}
