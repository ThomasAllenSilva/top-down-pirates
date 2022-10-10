using System;
using UnityEngine;

public class ShipHealthManager : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int ShipMaxHealth { get; private set; }

    public int CurrentShipHealth { get; private set; }

    public event Action OnTakeDamage;

    private EnemyShipController _enemyShipController;

    private void Awake() => CurrentShipHealth = ShipMaxHealth;

    private void ResetThisShipHealthValues()
    {
        CurrentShipHealth = ShipMaxHealth;
    }

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
        GameManager.Instance.ShipDeathAnimationEffectObjectPool.SpawnDeathAnimationEffectFromPool(transform.position, Quaternion.Euler(90f, transform.parent.eulerAngles.y, 0f));
        transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ResetThisShipHealthValues();
    }
}
