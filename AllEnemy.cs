using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemy : MonoBehaviour
{
    protected Animator animator;
    protected AudioSource deathAudio;
    protected Collider2D coll;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
        coll = GetComponent<Collider2D>();
    }

    public void Death(){
        Destroy(gameObject);
    }

    public void jumpOn(){
        //coll.enabled = false;
        animator.SetTrigger ("death");
        deathAudio.Play();
    }

}
