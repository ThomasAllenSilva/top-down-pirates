using System.Collections.Generic;
using UnityEngine;

public class ShipDeathAnimationEffectObjectPool : MonoBehaviour
{
    [SerializeField] private int _shipDeathAnimationEffectPoolSize = 25;

    [SerializeField] private GameObject _deathAnimationEffectPrefab;

    private Dictionary<string, Queue<GameObject>> _deathAnimationDictionary = new Dictionary<string, Queue<GameObject>>();

    private const string DeathAnimationEffectDictionaryTagName = "ShipDeathAnimationEffect";

    private void Start() => InitializeShipDeathAnimationEffectObjectPool();

    private void InitializeShipDeathAnimationEffectObjectPool()
    {
        Queue<GameObject> explosionsEffectObjectsQueue = new Queue<GameObject>();

        for (int i = 0; i < _shipDeathAnimationEffectPoolSize; i++)
        {
            GameObject shipDeathExplosionEffect = Instantiate(_deathAnimationEffectPrefab);

            shipDeathExplosionEffect.SetActive(false);

            explosionsEffectObjectsQueue.Enqueue(shipDeathExplosionEffect);
        }

        _deathAnimationDictionary.Add(DeathAnimationEffectDictionaryTagName, explosionsEffectObjectsQueue);
    }

    public void SpawnDeathAnimationEffectFromPool(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        GameObject explosionEffectSpawned = _deathAnimationDictionary[DeathAnimationEffectDictionaryTagName].Dequeue();

        explosionEffectSpawned.SetActive(true);

        explosionEffectSpawned.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

        _deathAnimationDictionary[DeathAnimationEffectDictionaryTagName].Enqueue(explosionEffectSpawned);
    }
}
