using UnityEngine;

public class CollisionWithPlayerHandler : MonoBehaviour
{
    [SerializeField] private int _damageThisShipWillGiveToPlayer;

    private void OnCollisionEnter(Collision collidedGameObject)
    {
        IDamageable collidedGameObjectIDamageable = collidedGameObject.gameObject.GetComponentInChildren<IDamageable>();

        if (collidedGameObjectIDamageable != null)
        {
            collidedGameObjectIDamageable.TakeDamage(_damageThisShipWillGiveToPlayer);
            transform.GetComponentInChildren<ShipHealthManager>().TakeDamage(100);
        }

   
    }
}
