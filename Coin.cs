using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject soundObject;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Instantiate(soundObject, 
                        transform.position, 
                        Quaternion.identity);
            Destroy(gameObject);
        }
    }
        
}
