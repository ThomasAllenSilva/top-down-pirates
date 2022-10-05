using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 25)]
    [SerializeField] private float _bulletMovementSpeed;

    [SerializeField] private int _bulletDamage;

    private void Update()
    {
        transform.position += _bulletMovementSpeed * Time.deltaTime * -transform.up;
    }

    public void SetBulletDamage(int bulletDamage)
    {
        _bulletDamage = bulletDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>().TakeDamage(_bulletDamage);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
