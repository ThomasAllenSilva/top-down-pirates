using System.Collections.Generic;
using UnityEngine;

public class EnemiesShipsObjectPooler : MonoBehaviour
{
    [SerializeField] private int _enemiesPoolSize = 10;

    [SerializeField] private GameObject _shooterEnemyPrefab;

    [SerializeField] private GameObject _chaserEnemyPrefab;

    private Dictionary<TypesOfEnemiesShips, Queue<GameObject>> _enemiesDictionary = new Dictionary<TypesOfEnemiesShips, Queue<GameObject>>();

    private void Start()
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

            default:

                Debug.Log(typeOfEnemy);
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

    public void SpawnEnemyShipFromPool(Vector3 positionToSpawn, TypesOfEnemiesShips typeOfEnemyToSpawn)
    {
        GameObject enemyShipSpawned = _enemiesDictionary[typeOfEnemyToSpawn].Dequeue();

        enemyShipSpawned.transform.position = positionToSpawn;

        enemyShipSpawned.SetActive(true);

        _enemiesDictionary[typeOfEnemyToSpawn].Enqueue(enemyShipSpawned);
    }
}