using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 25)]
    [SerializeField] private float _bulletMovementSpeed;

    private void Update()
    {
        transform.position += -1 * _bulletMovementSpeed * Time.deltaTime * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
