using System.Collections.Generic;
using UnityEngine;


public class BulletsObjectPool : MonoBehaviour
{
    [SerializeField] private int _bulletsPoolSize = 25;

    [SerializeField] private GameObject _bulletPrefab;

    private Dictionary<string, Queue<GameObject>> _bulletsDictionary = new Dictionary<string, Queue<GameObject>>();

    private const string BulletDictionaryTagName = "Bullet";

    private void Start() => InitializeNormalBulletsPool();
    
    private void InitializeNormalBulletsPool()
    {
        Queue<GameObject> bulletsObjectsQueue = new Queue<GameObject>();

        for (int i = 0; i < _bulletsPoolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);

            bulletsObjectsQueue.Enqueue(bullet);
        }

        _bulletsDictionary.Add(BulletDictionaryTagName, bulletsObjectsQueue);
    }

    public void SpawnNormalBullet(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
       GameObject normalBulletSpawned = _bulletsDictionary[BulletDictionaryTagName].Dequeue();

        normalBulletSpawned.SetActive(true);
        normalBulletSpawned.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

        _bulletsDictionary[BulletDictionaryTagName].Enqueue(normalBulletSpawned);
    }
}
