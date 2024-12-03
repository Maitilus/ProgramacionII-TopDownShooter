using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    private Transform Target;  
    public float Speed = 5;
    private Rigidbody2D rb;
    public float Damage = 5;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        Vector3 direction = Target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D ContactDamage)
    {
        if (ContactDamage.gameObject.TryGetComponent<HealthComponent>(out HealthComponent PlayerHealth))
        {
            PlayerHealth.TakeDamage(Damage);
        }
    }
}
