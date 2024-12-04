using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    [SerializeField] Weapon Weapon;
    public float BoostDuration = 10;
    public float FireRateMultiplier = 2;
    private bool IsActive;

    void OnCollisionEnter2D(Collision2D Pickup)
    {
        if (Pickup.gameObject.CompareTag("Player"))
        {
            StartCoroutine(IncreaseRPS());

            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<CircleCollider2D>());
        }
    }

    IEnumerator IncreaseRPS()
    {
        Weapon.RPS = Weapon.RegularRPS * FireRateMultiplier;
        yield return new WaitForSeconds(BoostDuration);
        Weapon.RPS = Weapon.RegularRPS;
    }
}
