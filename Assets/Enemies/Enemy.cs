using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100;
    public float Damage = 15;


    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float IncomingDamage)
    {
        Health -= IncomingDamage;
    }
}
