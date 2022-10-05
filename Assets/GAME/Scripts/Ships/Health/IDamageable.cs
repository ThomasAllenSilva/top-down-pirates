using System;

public interface IDamageable
{
    public void TakeDamage(int amountOfDamage);

    public event Action OnTakeDamage;
}
