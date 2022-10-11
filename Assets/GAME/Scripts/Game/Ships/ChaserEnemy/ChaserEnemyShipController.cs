using UnityEngine;

[RequireComponent(typeof(ChaserEnemyNavMeshAgentManager))]

public class ChaserEnemyShipController : MonoBehaviour
{
    public ShipHealthManager ShipHealthManager { get; private set; }

    private void Awake() => ShipHealthManager = GetComponentInChildren<ShipHealthManager>();

    private void OnDisable()
    {
        GameManager.Instance.EnemiesSpawner.ReduceAmountOfActiveEnemiesShipsCounter();
        GameManager.Instance.PlayerPointsManager.IncreasePlayerPoints();
    }
}
