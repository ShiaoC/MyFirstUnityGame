using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : AllButton
{
    public GameObject key;
    bool been = false;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();

    }

    void Update(){
        if ( animator.GetBool("done") && !been){
            key.SetActive(true);
            been = true;
        }
    }
}
