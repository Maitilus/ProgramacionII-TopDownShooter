using UnityEngine;

public class FlyingComponent : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    [SerializeField] float Steer = 30f;
    Rigidbody2D rb;
    private Transform Target;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * Speed * Time.deltaTime * 10f;
        Vector2 direction = (Target.position - transform.position).normalized;
        float RotationSteer = Vector3.Cross(transform.up, direction).z;     
        rb.angularVelocity = RotationSteer * Steer * 10f;
    }
}
