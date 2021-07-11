using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject keyShow;

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Player"){
            SoundManager.instance.KeyAudio();
            keyShow.SetActive(true);
            Destroy(gameObject);
        }
    }
}
