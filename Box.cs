using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject thingShow;
    Animator animator;
    bool haveBeen = true;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Player" && haveBeen){
            SoundManager.instance.BoxShowAudio();
            animator.SetTrigger ("used");
            thingShow.SetActive(true);
            haveBeen = false;
        }
    }
}
