using UnityEngine;

[RequireComponent(typeof(ChaserEnemyShipController))]

public class ChaserEnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] private int _damageThisShipWillGiveToPlayer;

    private ChaserEnemyShipController _shipController;

    private void Awake() => _shipController = GetComponent<ChaserEnemyShipController>();
    
    private void OnCollisionEnter(Collision collider)
    {
        IDamageable collidedGameObjectIDamageable = collider.gameObject.GetComponentInChildren<IDamageable>();

        if (collidedGameObjectIDamageable != null)
        {
            collidedGameObjectIDamageable.TakeDamage(_damageThisShipWillGiveToPlayer);
            _shipController.ShipHealthManager.TakeDamage(100);
        }
    }
}
