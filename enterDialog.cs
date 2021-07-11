using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterDialog : MonoBehaviour
{
    public GameObject dialogUnlock;
    
    void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "player"){
            dialogUnlock.SetActive(true);
        }
    }    

    void OnTriggerExit2D(Collider2D collision){

        if(collision.tag == "player"){
            dialogUnlock.SetActive(false);
        }
    }    
}
