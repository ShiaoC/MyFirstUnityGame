using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject key;

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.name == "Player" && !key){
            SoundManager.instance.UnlockAudio();
            Destroy(gameObject);
        }
    }
}
