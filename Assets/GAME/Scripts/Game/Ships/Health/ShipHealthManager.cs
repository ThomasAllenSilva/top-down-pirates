using System;
using UnityEngine;

public class ShipHealthManager : MonoBehaviour, IDamageable
{
    public event Action OnTakeDamage;

    [field: SerializeField] public int ShipMaxHealth { get; private set; }

    public int CurrentShipHealth { get; private set; }

    private void Awake() => CurrentShipHealth = ShipMaxHealth;

    public void TakeDamage(int amountOfDamage)
    {
        CurrentShipHealth -= amountOfDamage;
       
        if (CurrentShipHealth <= 0)
        {
            Die();
        }

        else
        {
            OnTakeDamage?.Invoke();
        }
    }

    private void Die()
    {
        GameManager.Instance.ShipDeathAnimationEffectObjectPool.SpawnDeathAnimationEffectFromPool(transform.position, Quaternion.Euler(90f, transform.rotation.y, 0f));
        gameObject.SetActive(false);
    }
}
