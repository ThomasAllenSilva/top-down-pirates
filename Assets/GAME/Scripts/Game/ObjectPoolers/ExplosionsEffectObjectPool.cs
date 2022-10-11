using System.Collections.Generic;
using UnityEngine;

public class ExplosionsEffectObjectPool : MonoBehaviour
{
    [SerializeField] private int _explosionsEffectPoolSize = 25;

    [SerializeField] private GameObject _explosionEffectPrefab;

    private readonly Queue<ExplosionEffect> _explosionsEffectDictionary = new Queue<ExplosionEffect>();

    private void Start() => InitializeExplosionsObjectPool();

    private void InitializeExplosionsObjectPool()
    {
        for (int i = 0; i < _explosionsEffectPoolSize; i++)
        {
            ExplosionEffect explosionEffect = Instantiate(_explosionEffectPrefab.GetComponent<ExplosionEffect>());

            explosionEffect.gameObject.SetActive(false);

            _explosionsEffectDictionary.Enqueue(explosionEffect);
        }
    }

    public void SpawnExplosionEffectFromPool(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        ExplosionEffect explosionEffectSpawned = _explosionsEffectDictionary.Dequeue();

        explosionEffectSpawned.gameObject.SetActive(true);

        explosionEffectSpawned.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

        _explosionsEffectDictionary.Enqueue(explosionEffectSpawned);
    }
}
