using System.Collections;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region Variables

    [Header("Weapon links")]
    public GameObject BulletPrefab;
    [Tooltip("Link the Projectile that will be Fired")]
    public Transform LBulletSpawn;
    public Transform RBulletSpawn;
    [Tooltip("Link The SpawnPont for the Projectile")]

    [Header("Stats of the Weapon")]
    public float FireForce;
    [Tooltip("The Speed of the Projectile")]
    public float RPS;
    [HideInInspector] public float RegularRPS;

    bool LeftCannonUsed;
    public bool CanFire = true;

    #endregion

    void Start()
    {
        RegularRPS = RPS;
    }

    public IEnumerator Fire()
    {
        CanFire = false;

        if (!LeftCannonUsed)
        {
            GameObject Bullet = Instantiate(BulletPrefab, LBulletSpawn.position, LBulletSpawn.rotation);
            Bullet.GetComponent<Rigidbody2D>().AddForce(LBulletSpawn.up * FireForce, ForceMode2D.Impulse);
            LeftCannonUsed = true;
        }
        else if (LeftCannonUsed)
        {
            GameObject Bullet = Instantiate(BulletPrefab, RBulletSpawn.position, RBulletSpawn.rotation);
            Bullet.GetComponent<Rigidbody2D>().AddForce(RBulletSpawn.up * FireForce, ForceMode2D.Impulse);
            LeftCannonUsed = false;
        }

        StartCoroutine(FireRateHander());
        yield return null;
    }

    IEnumerator FireRateHander()
    {
        float TimeToNextFire = 1 / RPS;
        yield return new WaitForSeconds(TimeToNextFire);
        CanFire = true;
    }

    void OnTriggerEnter2D(Collider2D PickUp)
    {
        if (PickUp.gameObject.TryGetComponent<FireRatePowerUp>(out FireRatePowerUp FireRatePowerUp))
        {
            StartCoroutine(FireRatePowerUpStart());
            FireRatePowerUp.DestroyOnPickup();
        }
    }

    IEnumerator FireRatePowerUpStart()
    {
        RPS *= 2;
        yield return new WaitForSeconds(10);
        RPS = RegularRPS;
    }
}
