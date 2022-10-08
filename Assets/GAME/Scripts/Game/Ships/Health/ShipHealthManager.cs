using System;
using UnityEngine;

public class ShipHealthManager : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int ShipMaxHealth { get; private set; }

    public int CurrentShipHealth { get; private set; }

    public event Action OnTakeDamage;

    private void Awake() => CurrentShipHealth = ShipMaxHealth;

    public void TakeDamage(int amountOfDamage)
    {
        CurrentShipHealth -= amountOfDamage;
        Debug.Log(CurrentShipHealth);
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
        GameManager.Instance.ShipDeathAnimationEffectObjectPool.SpawnDeathAnimationEffectFromPool(transform.position, transform.rotation);
        transform.parent.gameObject.SetActive(false);
    }
}
