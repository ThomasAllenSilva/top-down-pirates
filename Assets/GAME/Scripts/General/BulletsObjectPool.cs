using System.Collections.Generic;
using UnityEngine;


public class BulletsObjectPool : MonoBehaviour
{
    [SerializeField] private int _bulletsPoolSize = 25;

    [SerializeField] private GameObject _bulletPrefab;

    private Dictionary<string, Queue<Bullet>> _bulletsDictionary = new Dictionary<string, Queue<Bullet>>();

    private const string BulletDictionaryTagName = "Bullet";

    private void Start() => InitializeBulletsObjectsPool();
    
    private void InitializeBulletsObjectsPool()
    {
        Queue<Bullet> bulletsObjectsQueue = new Queue<Bullet>();

        for (int i = 0; i < _bulletsPoolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab.GetComponent<Bullet>());
            bullet.gameObject.SetActive(false);

            bulletsObjectsQueue.Enqueue(bullet);
        }

        _bulletsDictionary.Add(BulletDictionaryTagName, bulletsObjectsQueue);
    }

    public void SpawnBulletFromPool(Vector3 positionToSpawn, Quaternion rotationToSpawn, int bulletDamage)
    {
        Bullet bulletSpawned = _bulletsDictionary[BulletDictionaryTagName].Dequeue();

        bulletSpawned.gameObject.SetActive(true);

        bulletSpawned.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

        bulletSpawned.SetBulletDamage(bulletDamage);

        _bulletsDictionary[BulletDictionaryTagName].Enqueue(bulletSpawned);
    }
}
