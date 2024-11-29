using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    #region Variables
    [Header("Missie Stats")]
    [SerializeField] float Speed = 10f;
    [SerializeField] float Steer = 30f;
    float Lifetime = 12f;
    [SerializeField] float SplashRange = 1;
    [SerializeField] float Damage = 65;

    //Locked Target
    [SerializeField] Transform LockedTarget;

    public GameObject Explosion;

    Rigidbody2D rb;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Set the Speed And Homing values
        rb.linearVelocity = transform.up * Speed * Time.deltaTime * 10f;
        Vector2 direction = (LockedTarget.position - transform.position).normalized;
        float RotationSteer = Vector3.Cross(transform.up, direction).z;
        rb.angularVelocity = RotationSteer * Steer * 10f;
    }

    private void Awake()
    {
        Destroy(gameObject, Lifetime);

        //Find All enemies
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Declare var for Closest
        GameObject ClosestTarget = null;
        float DistanceToClosestTarget = 0;

        //Search for Closest
        foreach(GameObject Enemy in Enemies)
        {
            float DistanceToTarget = Vector3.Distance(transform.position, Enemy.transform.position);
            
            //Compare Distance
            if(ClosestTarget == null || DistanceToTarget < DistanceToClosestTarget)
            {
                DistanceToClosestTarget = DistanceToTarget;
                ClosestTarget = Enemy;
            }
        }

        //Set Target
        LockedTarget = ClosestTarget.transform; 
    }

    void OnCollisionEnter2D(Collision2D MissileCollision)
    {
        if (MissileCollision.gameObject.CompareTag("Enemy"))
        {
            GameObject Boom = Instantiate(Explosion, transform.position, transform.rotation);

            Destroy(gameObject);

            var HitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach (var HitCollider in HitColliders)
            {
                if (HitCollider.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
                {
                    Debug.Log("boom");
                    enemyComponent.TakeDamage(Damage);
                }
            }
        }
    }

}
