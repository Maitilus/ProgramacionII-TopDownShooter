using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class PlaneAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform LBulletSpawn;
    public Transform RBulletSpawn;
    public float FireForce;
    public float RPS;
    public bool CanFire = true;

    // Update is called once per frame
    void Update()
    {
        if (CanFire)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        GameObject BulletL = Instantiate(BulletPrefab, LBulletSpawn.position, LBulletSpawn.rotation);
        BulletL.GetComponent<Rigidbody2D>().AddForce(LBulletSpawn.up * FireForce, ForceMode2D.Impulse);

        GameObject BulletR = Instantiate(BulletPrefab, RBulletSpawn.position, RBulletSpawn.rotation);
        BulletR.GetComponent<Rigidbody2D>().AddForce(RBulletSpawn.up * FireForce, ForceMode2D.Impulse);

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
