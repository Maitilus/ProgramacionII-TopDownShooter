using System.Collections;
using UnityEngine;

public class MissilePowerUp : MonoBehaviour
{
    [SerializeField] MissileTurretScript MissileTurret;
    [SerializeField] MissileScript MissileProjectile;
    [SerializeField] GameObject BigExplosion;
    public float BoostDuration = 10;
    public float SplashRangeMultiplier = 1.5f;

    void OnTriggerEnter2D(Collider2D Pickup)
    {
        if (Pickup.gameObject.CompareTag("Player"))
        {
            StartCoroutine(IncreasePower());

            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<CircleCollider2D>());
        }
    }

    IEnumerator IncreasePower()
    {
        MissileProjectile.Damage *= SplashRangeMultiplier;
        MissileProjectile.SplashRange *= SplashRangeMultiplier;
        MissileProjectile.Explosion = BigExplosion;

        yield return new WaitForSeconds(BoostDuration);

        MissileProjectile.Damage = MissileProjectile.RegularDamage;
        MissileProjectile.SplashRange = MissileProjectile.RegularSplashRange;
        MissileProjectile.Explosion = MissileProjectile.RegularExplosion;
    }
}
