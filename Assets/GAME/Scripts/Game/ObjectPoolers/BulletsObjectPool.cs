using System.Collections.Generic;
using UnityEngine;

public class BulletsObjectPool : MonoBehaviour
{
    [SerializeField] private int _bulletsPoolSize = 25;

    [SerializeField] private GameObject _bulletPrefab;

    private readonly Queue<Bullet> _bulletsDictionary = new Queue<Bullet>();

    private void Start() => InitializeBulletsObjectPool();
    
    private void InitializeBulletsObjectPool()
    {
        for (int i = 0; i < _bulletsPoolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab.GetComponent<Bullet>());

            bullet.gameObject.SetActive(false);

            _bulletsDictionary.Enqueue(bullet);
        }
    }

    public void SpawnBulletFromPool(Vector3 positionToSpawn, Quaternion rotationToSpawn, int bulletDamage, int bulletLayer)
    {
        Bullet bulletSpawned = _bulletsDictionary.Dequeue();

        bulletSpawned.gameObject.layer = bulletLayer;

        bulletSpawned.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

        bulletSpawned.SetBulletDamage(bulletDamage);

        bulletSpawned.gameObject.SetActive(true);

        _bulletsDictionary.Enqueue(bulletSpawned);
    }
}
