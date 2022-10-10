using System.Collections;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _positionsToSpawnShips;

    private SpriteRenderer[] _spawnersRenderer;

    [SerializeField] private float _delayToSpawnEnemies;

    [Min(0.5f)]
    [SerializeField] private float _initialDelayToStartSpawningEnemies = 0.5f;

    private int _currentAmountOfActiveEnemiesShips = 0;

    private const int _maxAmountOfActiveEnemiesShipsOnScreen = 7;

    private void Awake()
    {
        _spawnersRenderer = new SpriteRenderer[_positionsToSpawnShips.Length];

        for (int i = 0; i < _positionsToSpawnShips.Length; i++)
        {
            _spawnersRenderer[i] = _positionsToSpawnShips[i].GetComponent<SpriteRenderer>();
        }
    }

    private void Start() => StartCoroutine(SpawnEnemies());

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSecondsRealtime(_initialDelayToStartSpawningEnemies);

        _currentAmountOfActiveEnemiesShips = 0;

        while (true)
        {
            if (CheckIfCanSpawnNewEnemies())
            {
                for (int i = 0; i < _positionsToSpawnShips.Length - 1; i++)
                {
                    if (CheckIfCanSpawnNewEnemies() && !CheckIfShipSpawnerIsVisible(spawnerIndex: i))
                    {
                        TypesOfEnemiesShips randomEnemy = (TypesOfEnemiesShips)Random.Range(0, 2);
                        GameManager.Instance.EnemiesShipsObjectPooler.SpawnEnemyShipFromPool(_positionsToSpawnShips[i].position, randomEnemy);    
                        _currentAmountOfActiveEnemiesShips++;
                    }
                }
            }

            yield return new WaitForSecondsRealtime(_delayToSpawnEnemies);
        }
    }

    private bool CheckIfCanSpawnNewEnemies()
    {
        if (_currentAmountOfActiveEnemiesShips <= _maxAmountOfActiveEnemiesShipsOnScreen)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    private bool CheckIfShipSpawnerIsVisible(int spawnerIndex)
    {
        if (_spawnersRenderer[spawnerIndex].isVisible)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void ReduceAmountOfActiveEnemiesShipsCounter()
    {
        if(_currentAmountOfActiveEnemiesShips > 0)
        _currentAmountOfActiveEnemiesShips--;
    }
}
