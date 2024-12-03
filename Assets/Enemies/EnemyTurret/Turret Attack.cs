using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletSpawn;
    public float FireForce;
    public float RPS;
    public bool CanFire = true;

    void Update()
    {
        if (CanFire)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        GameObject Bullet = Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(BulletSpawn.right * FireForce, ForceMode2D.Impulse);

        CanFire = false;
        StartCoroutine(FireRateHander());
        yield return null;
    }

    IEnumerator FireRateHander()
    {
        //Calculate the Fire Rate
        float TimeToNextFire = 1 / RPS;
        yield return new WaitForSeconds(TimeToNextFire);
        CanFire = true;
    }
}
