using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Lifetime = 2;
    public int Damage = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthComponent>(out HealthComponent enemyComponent))
        {
            enemyComponent.TakeDamage(Damage);
        }

        if(!collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, Lifetime);
    }
}
