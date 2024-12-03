using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemySwarmerSmall;
    [SerializeField] private GameObject EnemySwarmerBig;
    [SerializeField] private GameObject EnemyPlane;
    [SerializeField] private GameObject EnemyTurret;

    [SerializeField] private float MinSpawnInterval;
    [SerializeField] private float MaxSpawnInterval;
    [SerializeField] private float TimeUntilSpawn;


    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    private void Update()
    {
        TimeUntilSpawn -= Time.deltaTime;

        if (TimeUntilSpawn <= 0)
        {
            int EnemyToSpawn = Random.Range(1, 6);
            
            if (EnemyToSpawn >= 0 && EnemyToSpawn < 2)
            {
                Instantiate(EnemySwarmerSmall, transform.position, Quaternion.identity);
            }
            else if (EnemyToSpawn >= 2 && EnemyToSpawn < 3)
            {
                Instantiate(EnemySwarmerBig, transform.position, Quaternion.identity);
            }
            else if (EnemyToSpawn >= 3 && EnemyToSpawn < 5)
            {
                Instantiate(EnemyPlane, transform.position, Quaternion.identity);
            }
            else if (EnemyToSpawn >= 5)
            {
                Instantiate(EnemyTurret, transform.position, Quaternion.identity);
            }

            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        TimeUntilSpawn = Random.Range(MinSpawnInterval, MaxSpawnInterval);
    }

}
