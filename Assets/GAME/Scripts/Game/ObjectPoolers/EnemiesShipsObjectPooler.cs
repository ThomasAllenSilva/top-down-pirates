using System.Collections.Generic;
using UnityEngine;

public class EnemiesShipsObjectPooler : MonoBehaviour
{
    [SerializeField] private int _enemiesPoolSize = 50;

    [SerializeField] private GameObject _shooterEnemyPrefab;

    [SerializeField] private GameObject _chaserEnemyPrefab;

    private Dictionary<TypesOfEnemiesShips, Queue<GameObject>> _enemiesDictionary = new Dictionary<TypesOfEnemiesShips, Queue<GameObject>>();

    private void Awake()
    {
        InitializeEnemyObjectPool(TypesOfEnemiesShips.ShooterEnemy);
        InitializeEnemyObjectPool(TypesOfEnemiesShips.ChaserEnemy);
    }

    private void InitializeEnemyObjectPool(TypesOfEnemiesShips typeOfEnemy)
    {
        Queue<GameObject> enemyShipsQueue = new Queue<GameObject>();

        GameObject typeOfEnemyShipToSpawn = null;

        switch (typeOfEnemy)
        {
            case TypesOfEnemiesShips.ShooterEnemy:
                typeOfEnemyShipToSpawn = _shooterEnemyPrefab;
                break;

            case TypesOfEnemiesShips.ChaserEnemy:
                typeOfEnemyShipToSpawn = _chaserEnemyPrefab;
                break;
        }

        for (int i = 0; i < _enemiesPoolSize * 0.5f; i++)
        {
            GameObject enemyShip = Instantiate(typeOfEnemyShipToSpawn);

            enemyShip.SetActive(false);

            enemyShipsQueue.Enqueue(enemyShip);
        }

        _enemiesDictionary.Add(typeOfEnemy, enemyShipsQueue);
    }

    public bool SpawnEnemyShipFromPool(Vector3 positionToSpawn, TypesOfEnemiesShips typeOfEnemyToSpawn)
    {
        _enemiesDictionary[typeOfEnemyToSpawn].TryDequeue(out GameObject enemyShipSpawned);

        _enemiesDictionary[typeOfEnemyToSpawn].Enqueue(enemyShipSpawned);

        if (!enemyShipSpawned.activeInHierarchy)
        {
            enemyShipSpawned.transform.position = positionToSpawn;

            enemyShipSpawned.SetActive(true);

            return true;
        }

        else return false;
    }
}