using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public ShipNavMeshManager ShipNavMeshManager { get; private set; }

    private void Awake() => ShipNavMeshManager = GetComponent<ShipNavMeshManager>();
}
