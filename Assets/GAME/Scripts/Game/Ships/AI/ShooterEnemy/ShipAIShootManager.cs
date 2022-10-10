using System.Collections;
using UnityEngine;

public class ShipAIShootManager : MonoBehaviour
{
    private EnemyShipController _shipController;

    [SerializeField] private float _shootDelay;

    [SerializeField] private Transform _shootSpawnPoint;

    [SerializeField] private int _bulletDamageFromThisEnemy;
    
    private bool canShoot;

    private bool shootCoroutineIsAlreadyRunnning;

    private void Awake() => _shipController = transform.parent.GetComponent<EnemyShipController>();

    private void Start()
    {
        _shipController.ShipNavMeshManager.OnReachedPositionCloseEnoughToPlayer += SetCanShootBoolToTrue;
        _shipController.ShipNavMeshManager.OnIsFarFromPlayerPlayer += SetCanShootBoolToFalse;
    }

    private IEnumerator Shoot()
    {
        if (!shootCoroutineIsAlreadyRunnning)
        {
            shootCoroutineIsAlreadyRunnning = true;

            while (canShoot)
            {
                GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_shootSpawnPoint.position, transform.rotation, 1, gameObject.layer);
                yield return new WaitForSecondsRealtime(_shootDelay);
            }

            shootCoroutineIsAlreadyRunnning = false;
        }
    }

  

    private void SetCanShootBoolToTrue()
    {
        canShoot = true;
        StartCoroutine(Shoot());
    }

    private void SetCanShootBoolToFalse()
    {
        canShoot = false;
    }

    private void OnDisable()
    {
        shootCoroutineIsAlreadyRunnning = false;
    }

    private void OnDestroy()
    {
        if (_shipController != null)
        {
            _shipController.ShipNavMeshManager.OnReachedPositionCloseEnoughToPlayer -= SetCanShootBoolToTrue;
            _shipController.ShipNavMeshManager.OnIsFarFromPlayerPlayer -= SetCanShootBoolToFalse;
        }
    }

}
