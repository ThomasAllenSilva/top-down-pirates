using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public ShooterEnemyNavMeshManager ShipNavMeshManager { get; private set; }

    private void Awake() => ShipNavMeshManager = GetComponent<ShooterEnemyNavMeshManager>();

    private void OnDisable()
    {
        GameManager.Instance.EnemiesSpawner.ReduceAmountOfActiveEnemiesShipsCounter();
        GameManager.Instance.PlayerPointsManager.IncreasePlayerPoints();
    }
}
