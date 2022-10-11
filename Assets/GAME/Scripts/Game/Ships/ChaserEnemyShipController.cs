using UnityEngine;

[RequireComponent(typeof(ChaserEnemyNavMeshAgentManager))]

public class ChaserEnemyShipController : MonoBehaviour
{
    public ShipHealthManager ShipHealthManager { get; private set; }

    private ChaserEnemyNavMeshAgentManager shipNavMeshManager;

    [Range(1f, 5f)] [SerializeField] private float _defaultShipMovementSpeed = 2;

    private void Awake()
    {
        ShipHealthManager = GetComponentInChildren<ShipHealthManager>();
        shipNavMeshManager = GetComponent<ChaserEnemyNavMeshAgentManager>();
    }

    private void Start() => shipNavMeshManager.SetShipMovementSpeed(_defaultShipMovementSpeed);

    private void OnDisable()
    {
        GameManager.Instance.EnemiesSpawner.ReduceAmountOfActiveEnemiesShipsCounter();
        GameManager.Instance.PlayerPointsManager.IncreasePlayerPoints();
    }
}
