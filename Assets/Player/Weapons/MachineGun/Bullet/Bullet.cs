using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Lifetime = 2;
    public int Damage = 15;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy the Projectile
        Destroy(gameObject);

        //Destroy the Enemy
        if (collision.gameObject.TryGetComponent<HealthComponent>(out HealthComponent enemyComponent))
        {
            enemyComponent.TakeDamage(Damage);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, Lifetime);
    }
}
