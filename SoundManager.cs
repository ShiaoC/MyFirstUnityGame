using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioSource BGM;
    [SerializeField]
    AudioClip jump, hurt, coin, key, unlock, clickButton, boxShow;
    //[SerializeField]
    //AudioClip enemyGround, enemyFlying;

    private void Awake(){
        instance = this;
    }
////////////////////////////////////////
    public void JumpAudio(){
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void HurtAudio(){
        audioSource.clip = hurt;
        audioSource.Play();
    }

    public void CoinAudio(){
        audioSource.clip = coin;
        audioSource.Play();
    }

    public void KeyAudio(){
        audioSource.clip = key;
        audioSource.Play();
    }

    public void UnlockAudio(){
        audioSource.clip = unlock;
        audioSource.Play();
    }

    public void ClickButtonAudio(){
        audioSource.clip = clickButton;
        audioSource.Play();
    }

    public void BoxShowAudio(){
        audioSource.clip = boxShow;
        audioSource.Play();
    }

    /*public void EnemyGroundAudio(){
        audioSource.clip = enemyGround;
        audioSource.Play();
    }

    public void EnemyFlyingAudio(){
        audioSource.clip = enemyFlying;
        audioSource.Play();
    }*/

    public void BGMstop(){
        BGM.Stop();
    }

}
