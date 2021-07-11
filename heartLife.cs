using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartLife : MonoBehaviour
{
    public static heartLife instance;
    public GameObject Heart01;
    public GameObject Heart02;
    public GameObject Heart03;
    bool check = true;
    int lastCoin = GameDataManager.coin;

    private void Awake(){
        instance = this;
    }
    void PlayGame(){
        check = true;
    }

    public void heartCheck(int HeartNum){
        //heartNum = HeartNum;
        if (HeartNum <= 2){
            Heart01.SetActive(false);
        }
        if (HeartNum <= 1){
            Heart02.SetActive(false);
        }
        if (HeartNum <= 0 && check){
            check=false;
            GameDataManager.coin = lastCoin;
            SoundManager.instance.BGMstop();
            Heart03.SetActive(false);
            Menu.instance.DeathMenu();
            
            
        }
    }
}
