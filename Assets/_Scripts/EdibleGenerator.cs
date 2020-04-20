using System;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class EdibleGenerator : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Location location;
    [SerializeField] private GameObject[] edibles;
    [SerializeField] private float minXVelocity;
    [SerializeField] private float maxXVelocity;
    [SerializeField] private float minYVelocity;
    [SerializeField] private float maxYVelocity;
    [SerializeField] private float minMagnitude;
    [SerializeField] private float maxMagnitude;

    [Space]
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    
    

    private float _timeBetweenSpawns;
    private float _timer = 0;
    private float _initialTimer;
    private float _startSpawnTime = 6.0f;
    private float _width;
    private float _height;
    private Vector3 _size;
    private float _thickness = 0.5f;
    
    private void Start()
    {
        _timeBetweenSpawns = Random.Range(minSpawnTime, maxSpawnTime);
        _width = (GameManager.Instance.mainCamera.orthographicSize * 2.0f * Screen.width / Screen.height);
        _height = (GameManager.Instance.mainCamera.orthographicSize * Screen.width / Screen.height);
        
        ApplyDimensionsAndLocation();
        
        // InvokeRepeating("SpawnEdible", timeToStartSpawning, timeBetweenSpawns);
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver) return;
        
        if (_initialTimer < _startSpawnTime)
        {
            _initialTimer += Time.deltaTime;
            return;
        }
            
        _timer += Time.deltaTime;
        if (_timer < _timeBetweenSpawns) return;
        SpawnEdible();
        _timer = 0f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(position, _size);
    }

    private void ApplyDimensionsAndLocation()
    {
        switch (location)
        {
            case Location.Bottom:
                _size = new Vector3(_width, _thickness, 0);
                position = new Vector3(0, -_height/2 - _thickness, 0);
                break;
            case Location.Top:
                _size = new Vector3(_width, _thickness, 0);
                position = new Vector3(0, _height/2 + _thickness, 0);
                break;
            case Location.Left:
                _size = new Vector3(_thickness, _height, 0);
                position = new Vector3(-_width/2 - _thickness, 0, 0);
                break;
            case Location.Right:
                _size = new Vector3(_thickness, _height, 0);
                position = new Vector3(_width/2 + _thickness, 0, 0);
                break;
            default:
                Debug.LogError("Edible spawner location has not been selected!");
                break;
        }
    }

    private void SpawnEdible()
    {
        _timeBetweenSpawns = Random.Range(minSpawnTime, maxSpawnTime);
        int edibleType = Random.Range(0, edibles.Length);
        float spawnX = Random.Range(_size.x / -2, _size.x / 2);
        float spawnY = Random.Range(_size.y / -2, _size.y / 2);
        GameObject edible = Instantiate(edibles[edibleType], new Vector2(spawnX + position.x, spawnY + position.y), Quaternion.identity);
        edible.GetComponent<Rigidbody2D>().AddForce(CalculateVelocity());
        
    }

    private Vector3 CalculateVelocity()
    {
        float xVelocity = Random.Range(minXVelocity, maxXVelocity);
        float yVelocity = Random.Range(minYVelocity, maxYVelocity);

        float magnitude = Random.Range(minMagnitude, maxMagnitude);
        
        return new Vector3(xVelocity, yVelocity).normalized * magnitude;
    }

    public enum Location
    {
        Left, Right, Top, Bottom
    }
    
    
}
