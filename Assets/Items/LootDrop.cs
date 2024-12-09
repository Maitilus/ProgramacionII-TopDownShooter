using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public float DropChance;
    public GameObject[] ItemPool;
    public void DropItem()
    {
        float RNG = UnityEngine.Random.Range(1, 101);
        if(RNG <= DropChance)
        {
            Instantiate(ItemPool[UnityEngine.Random.Range(0, ItemPool.Length)], transform.position, quaternion.identity);
        }
    }
}
