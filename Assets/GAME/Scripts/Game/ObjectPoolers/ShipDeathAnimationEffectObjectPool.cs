using System.Collections.Generic;
using UnityEngine;

public class ShipDeathAnimationEffectObjectPool : MonoBehaviour
{
    [SerializeField] private int _shipDeathAnimationEffectPoolSize = 25;

    [SerializeField] private GameObject _deathAnimationEffectPrefab;

    private Queue<GameObject> _shipDeathAnimationDictionary = new Queue<GameObject>();

    private void Start() => InitializeShipDeathAnimationEffectObjectPool();

    private void InitializeShipDeathAnimationEffectObjectPool()
    {
        for (int i = 0; i < _shipDeathAnimationEffectPoolSize; i++)
        {
            GameObject shipDeathExplosionEffect = Instantiate(_deathAnimationEffectPrefab);

            shipDeathExplosionEffect.SetActive(false);

            _shipDeathAnimationDictionary.Enqueue(shipDeathExplosionEffect);
        }
    }

    public void SpawnDeathAnimationEffectFromPool(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        GameObject explosionEffectSpawned = _shipDeathAnimationDictionary.Dequeue();

        explosionEffectSpawned.SetActive(true);

        explosionEffectSpawned.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

        _shipDeathAnimationDictionary.Enqueue(explosionEffectSpawned);
    }
}
