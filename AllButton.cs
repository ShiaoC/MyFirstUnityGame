using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllButton : MonoBehaviour
{
    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void clickButton(){
        if(!animator.GetBool("done")){
            animator.SetBool ("done",true);
            SoundManager.instance.ClickButtonAudio();
        }
    }
}
