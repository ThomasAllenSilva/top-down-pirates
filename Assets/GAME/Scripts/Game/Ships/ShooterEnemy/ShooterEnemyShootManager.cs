using System.Collections;
using UnityEngine;

public class ShooterEnemyShootManager : MonoBehaviour
{
    [SerializeField] private Transform _shootSpawnPoint;

    [SerializeField] private float _shootDelay;

    [SerializeField] private int _bulletDamageFromThisEnemy;
    
    private bool canShoot;

    private bool shootCoroutineIsAlreadyRunnning;

    private ShooterEnemyShipController _shipController;

    private void Awake() => _shipController = transform.parent.GetComponent<ShooterEnemyShipController>();

    private void Start()
    {
        _shipController.ShipNavMeshManager.OnReachedPositionCloseEnoughToPlayer += StartShootingOnPlayer;

        _shipController.ShipNavMeshManager.OnIsFarFromPlayerPlayer += StopShootingOnPlayer;

        GameManager.Instance.GameSessionManager.OnGameSessionStopped += StopShootingOnPlayer;
    }

    private IEnumerator Shoot()
    {
        canShoot = true;

        if (!shootCoroutineIsAlreadyRunnning)
        {
            shootCoroutineIsAlreadyRunnning = true;

            while (canShoot)
            {
                GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_shootSpawnPoint.position, transform.rotation, _bulletDamageFromThisEnemy, gameObject.layer);
                yield return new WaitForSecondsRealtime(_shootDelay);
            }

            shootCoroutineIsAlreadyRunnning = false;
        }
    }

    private void StartShootingOnPlayer()
    {    
        StartCoroutine(Shoot());
    }

    private void StopShootingOnPlayer()
    {
        canShoot = false;
    }

    private void OnDisable() => shootCoroutineIsAlreadyRunnning = false;
    
    private void OnDestroy()
    {
        if (_shipController != null)
        {
            _shipController.ShipNavMeshManager.OnReachedPositionCloseEnoughToPlayer -= StartShootingOnPlayer;
            _shipController.ShipNavMeshManager.OnIsFarFromPlayerPlayer -= StopShootingOnPlayer;
        }

        if(GameManager.Instance != null)
        {
            GameManager.Instance.GameSessionManager.OnGameSessionStopped -= StopShootingOnPlayer;
        }
    }
}
