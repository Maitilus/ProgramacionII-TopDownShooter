using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float CurrentHealth = 100;
    public float MaxHealth = 100;

    void Update()
    {
        if (CurrentHealth <= 0 && !gameObject.CompareTag("Player"))
        {
            if (gameObject.TryGetComponent<LootDrop>(out LootDrop LootDrop))
            {
                LootDrop.DropItem();
            }

            Destroy(gameObject);    
        }
    }

    public void TakeDamage(float IncomingDamage)
    {
        CurrentHealth -= IncomingDamage;
    }
}
