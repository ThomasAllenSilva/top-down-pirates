using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class EnemiesSpawnerManager : MonoBehaviour
{
    [SerializeField] private Transform[] _positionsToSpawnShips;

    [SerializeField] private int _maxActiveEnemiesShipsOnScreen = 7;

    private SpriteRenderer[] _spawnersRenderers;

    private float _delayToSpawnEnemies;

    private int _currentAmountOfActiveEnemiesShips = 0;

    private GameManager _gameManager;

    private void Awake()
    {
        _spawnersRenderers = new SpriteRenderer[_positionsToSpawnShips.Length];

        for (int i = 0; i < _positionsToSpawnShips.Length; i++)
        {
            _spawnersRenderers[i] = _positionsToSpawnShips[i].GetComponent<SpriteRenderer>();
        }

        _gameManager = GameManager.Instance;
    }

    private void Start() => SpawnEnemies();

    private async void SpawnEnemies()
    {
        await Task.Delay(_delayToSpawnEnemies);

        _currentAmountOfActiveEnemiesShips = 0;

        while (_gameManager.GameIsRunning)
        {
            if (CheckIfCanSpawnNewEnemies())
            {   
                for (int i = _currentAmountOfActiveEnemiesShips; i < _maxActiveEnemiesShipsOnScreen; i++)
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

            await Task.Delay(_delayToSpawnEnemies);
        }
    }

    private bool CheckIfCanSpawnNewEnemies()
    {
        return _currentAmountOfActiveEnemiesShips < _maxActiveEnemiesShipsOnScreen;
    }

    private bool CheckIfShipSpawnerIsVisible(int spawnerIndex)
    {
        return _spawnersRenderers[spawnerIndex].isVisible;
    }

    public void ReduceAmountOfActiveEnemiesShipsCounter()
    {   
        if (_currentAmountOfActiveEnemiesShips > 0) _currentAmountOfActiveEnemiesShips--;
    }

    public void SetDelayToSpawnEnemies(float delay)
    {
        _delayToSpawnEnemies = delay;
    }
}
