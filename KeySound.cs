using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySound : MonoBehaviour
{
    public GameObject ShowKey;
    //bool been = false;
    public AudioSource keyAudio;
    playerController player;
    Animator animator;
    
    void Start(){
        animator = GetComponent<Animator>();
    }

    public void keychange(){
        animator.SetBool ("have", true);
    }
    
    /*void Update()
    {
        if( !been ){
            if(ShowKey.activeSelf){
                GetComponent<AudioSource>().Play();
                been = true;
                playerController player = gameObject.GetComponent<playerController>();
                player.keychange();
            }
        }
    }*/
}
