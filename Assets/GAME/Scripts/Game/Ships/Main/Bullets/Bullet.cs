using UnityEngine;

public class Bullet : MonoBehaviour
{
    private static GameManager _gameManager;

    [Range(0, 25)] [SerializeField] private float _bulletMovementSpeed;

    private int _bulletDamage;

    private void Start() => _gameManager = GameManager.Instance;
    
    private void Update() => transform.position += _bulletMovementSpeed * Time.deltaTime * -transform.up;
    
    public void SetBulletDamage(int bulletDamage)
    {
        _bulletDamage = bulletDamage;
    }

    private void OnTriggerEnter(Collider collidedGameObject)
    {
        IDamageable collidedGameObjectIDamageable = collidedGameObject.gameObject.GetComponentInChildren<IDamageable>();

        if (collidedGameObjectIDamageable != null)
        {
            collidedGameObjectIDamageable.TakeDamage(_bulletDamage);
        }

        _gameManager.ExplosionsEffectObjectPool.SpawnExplosionEffectFromPool(transform.position, transform.rotation);

        gameObject.SetActive(false);
    }

    private void OnBecameInvisible() => gameObject.SetActive(false);
}
