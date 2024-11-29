using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Weapon Weapon;
    public float Lifetime = 2;
    public int Damage = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy the Projectile
        Destroy(gameObject);

        //Destroy the Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, Lifetime);
    }
}
