using System.Collections;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    public void DestroyOnPickup()
    {
        Destroy(gameObject);
    }
}
