using System;
using UnityEngine;

public class ShipHealthManager : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int ShipHealth { get; private set; }

    [SerializeField] private GameObject _shipDeathExplosion;

    public event Action OnTakeDamage;

    public void TakeDamage(int amountOfDamage)
    {
        ShipHealth -= amountOfDamage;
       
        if (ShipHealth <= 0)
        {
            Die();
        }

        else
        {
            OnTakeDamage?.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(1);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        
    }
}
