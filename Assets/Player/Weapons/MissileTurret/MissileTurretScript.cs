using System.Collections;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class MissileTurretScript : MonoBehaviour
{

#region Variables

    [Header("Weapon links")]
    public GameObject MissilePrefab;
    [Tooltip("Link the Projectile that will be Fired")]
    public Transform MissileSpawn;
    [Tooltip("Link The SpawnPont for the Projectile")]

    [Header("Stats of the Weapon")]
    public float RPS;
    public float RegularRPS;

    [HideInInspector] public bool CanFire = true;

    #endregion

    void Start()
    {
        RegularRPS = RPS;
    }

    void Update()
    {
        if(CanFire)
        {
            StartCoroutine(Fire());
        }
    }
    public IEnumerator Fire()
    {
        CanFire = false;

        GameObject Bullet = Instantiate(MissilePrefab, MissileSpawn.position, MissileSpawn.rotation);

        StartCoroutine(FireRateHanlder());
        yield return null;
    }

    IEnumerator FireRateHanlder()
    {
        float TimeToNextFire = 1 / RPS;
        yield return new WaitForSeconds(TimeToNextFire);
        CanFire = true;
    }
}
