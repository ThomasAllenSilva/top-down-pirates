using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 25)]
    [SerializeField] private float _bulletMovementSpeed;

    private int _bulletDamage;

    private static GameManager _gameManager;

    private void Start() => _gameManager = GameManager.Instance;
    
    private void Update() => transform.position += _bulletMovementSpeed * Time.deltaTime * -transform.up;
    
    public void SetBulletDamage(int bulletDamage)
    {
        _bulletDamage = bulletDamage;
    }

    private void OnCollisionEnter2D(Collision2D collidedGameObject)
    {
        IDamageable collidedGameObjectIDamageable = collidedGameObject.gameObject.GetComponent<IDamageable>();

        if (collidedGameObjectIDamageable != null)
        {
            collidedGameObjectIDamageable.TakeDamage(_bulletDamage);
        }

        _gameManager.ExplosionsEffectObjectPool.SpawnExplosionEffectFromPool(transform.position, transform.rotation, 0.3f);

        gameObject.SetActive(false);
    }

    private void OnBecameInvisible() => gameObject.SetActive(false);
}
