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
    [SerializeField] float RPS;

    [HideInInspector] public bool CanFire = true;

    #endregion


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

        //Spawn the Missile
        GameObject Bullet = Instantiate(MissilePrefab, MissileSpawn.position, MissileSpawn.rotation);

        //Shot CoolDown
        StartCoroutine(FireRateHanlder());
        yield return null;
    }

    IEnumerator FireRateHanlder()
    {
        //Calculate the Fire Rate
        float TimeToNextFire = 1 / RPS;
        yield return new WaitForSeconds(TimeToNextFire);
        CanFire = true;
    }
}
