using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _positionsToSpawnShips;

    private SpriteRenderer[] _spawnersRenderer;

    private float _delayToSpawnEnemies;

    [Min(2f)]
    [SerializeField] private float _initialDelayToStartSpawningEnemies =2f;

    private int _currentAmountOfActiveEnemiesShips = 0;

    private const int _maxAmountOfActiveEnemiesShipsOnScreen = 7;

    private GameManager _gameManager;

    private void Awake()
    {
        _spawnersRenderer = new SpriteRenderer[_positionsToSpawnShips.Length];

        for (int i = 0; i < _positionsToSpawnShips.Length; i++)
        {
            _spawnersRenderer[i] = _positionsToSpawnShips[i].GetComponent<SpriteRenderer>();
        }

        _gameManager = GameManager.Instance;
    }

    private void Start() => StartCoroutine(SpawnEnemies());

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSecondsRealtime(_initialDelayToStartSpawningEnemies);

        _currentAmountOfActiveEnemiesShips = 0;

        while (_gameManager.GameIsRunning)
        {
            if (CheckIfCanSpawnNewEnemies())
            {   
                for (int i = 0; i < _positionsToSpawnShips.Length - 1; i++)
                {
                    int randomPositionToSpawn = Random.Range(0, _positionsToSpawnShips.Length - 1);

                    if (CheckIfCanSpawnNewEnemies() && !CheckIfShipSpawnerIsVisible(spawnerIndex: randomPositionToSpawn))
                    {
                        
                        TypesOfEnemiesShips randomEnemy = (TypesOfEnemiesShips)Random.Range(0, 2);

                        bool spawnedEnemyShipSuccessfully = _gameManager.EnemiesShipsObjectPooler.SpawnEnemyShipFromPool(_positionsToSpawnShips[randomPositionToSpawn].position, randomEnemy); 

                        if(spawnedEnemyShipSuccessfully) _currentAmountOfActiveEnemiesShips++;
                    }
                }
            }

            yield return new WaitForSecondsRealtime(_delayToSpawnEnemies);
        }
    }

    public void SetDelayToSpawnEnemies(float delay)
    {
        _delayToSpawnEnemies = delay;
    }

    private bool CheckIfCanSpawnNewEnemies()
    {
        return _currentAmountOfActiveEnemiesShips < _maxAmountOfActiveEnemiesShipsOnScreen;
    }

    private bool CheckIfShipSpawnerIsVisible(int spawnerIndex)
    {
        return _spawnersRenderer[spawnerIndex].isVisible;
    }

    public void ReduceAmountOfActiveEnemiesShipsCounter()
    {   
        if (_currentAmountOfActiveEnemiesShips > 0) _currentAmountOfActiveEnemiesShips--;
    }
}
