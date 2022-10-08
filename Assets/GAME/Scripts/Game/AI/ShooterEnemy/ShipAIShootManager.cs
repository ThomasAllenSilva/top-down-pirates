using System.Collections;
using UnityEngine;

public class ShipAIShootManager : MonoBehaviour
{
    private EnemyShipController _shipController;

    [SerializeField] private float _shootDelay;

    private bool canShoot;

    private void Awake() => _shipController = transform.parent.GetComponent<EnemyShipController>();

    private IEnumerator Shoot()
    {
        while (canShoot)
        {
            GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(transform.parent.position, transform.rotation, 1, gameObject.layer);
            yield return new WaitForSecondsRealtime(_shootDelay);
        }
    }

    private void Start()
    {
        _shipController.ShipNavMeshManager.OnReachedPositionCloseEnoughToPlayer += SetCanShootBoolToTrue;
        _shipController.ShipNavMeshManager.OnIsFarFromPlayerPlayer += SetCanShootBoolToFalse;
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
        _shipController.ShipNavMeshManager.OnReachedPositionCloseEnoughToPlayer -= SetCanShootBoolToTrue;
        _shipController.ShipNavMeshManager.OnIsFarFromPlayerPlayer -= SetCanShootBoolToFalse;
    }
}
