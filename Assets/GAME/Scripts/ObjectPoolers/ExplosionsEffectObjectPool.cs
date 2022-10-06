using System.Collections.Generic;
using UnityEngine;

public class ExplosionsEffectObjectPool : MonoBehaviour
{
    [SerializeField] private int _explosionsEffectPoolSize = 25;

    [SerializeField] private GameObject _explosionEffectPrefab;

    private Dictionary<string, Queue<ExplosionEffect>> _explosionsEffectDictionary = new Dictionary<string, Queue<ExplosionEffect>>();

    private const string ExplosionsDictionaryTagName = "ExplosionEffect";

    private void Start() => InitializeExplosionsObjectPool();

    private void InitializeExplosionsObjectPool()
    {
        Queue<ExplosionEffect> explosionsEffectObjectsQueue = new Queue<ExplosionEffect>();

        for (int i = 0; i < _explosionsEffectPoolSize; i++)
        {
            ExplosionEffect explosionEffect = Instantiate(_explosionEffectPrefab.GetComponent<ExplosionEffect>());

            explosionEffect.gameObject.SetActive(false);

            explosionsEffectObjectsQueue.Enqueue(explosionEffect);
        }

        _explosionsEffectDictionary.Add(ExplosionsDictionaryTagName, explosionsEffectObjectsQueue);
    }

    public void SpawnExplosionEffectFromPool(Vector3 positionToSpawn, Quaternion rotationToSpawn, float explosionScale)
    {
        ExplosionEffect explosionEffectSpawned = _explosionsEffectDictionary[ExplosionsDictionaryTagName].Dequeue();

        explosionEffectSpawned.SetExplosionEffectScale(explosionScale);

        explosionEffectSpawned.gameObject.SetActive(true);

        explosionEffectSpawned.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

        _explosionsEffectDictionary[ExplosionsDictionaryTagName].Enqueue(explosionEffectSpawned);
    }
}
