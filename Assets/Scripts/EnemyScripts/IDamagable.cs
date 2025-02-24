using UnityEngine;

public interface IDamagable
{
    void Damage(float DamageAmount);

    void Die();

    float MaxHealth {  get; set; }
    float currentHealth { get; set; }
}
