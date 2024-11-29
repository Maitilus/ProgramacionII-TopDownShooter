using Unity.VisualScripting;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 0.5f);
    }
}
