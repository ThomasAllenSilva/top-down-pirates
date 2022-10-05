using System;
using UnityEngine;

public class ShipHealthManager : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int ShipHealth { get; private set; }

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
            TakeDamage(0);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
