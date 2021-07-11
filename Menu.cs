using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public static Menu instance;
    public GameObject pauseMenu;
    public GameObject settingMenu;
    public GameObject winMenu;
    public GameObject deathMenu;
    public GameObject SuperHint;

    public AudioMixer MainAudio;
    public AudioMixer OtherAudio;

    private void Awake(){
        instance = this;
    }

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
    }

    public void UIEnable(){
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);
    }
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoMenu(){
        SceneManager.LoadScene(0);
    }
    public void Setting(){
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
    public void BackMainMenu(){
        pauseMenu.SetActive(true);
        settingMenu.SetActive(false);
    }
    public void DeathMenu(){
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
    }
    public void WinMenu(){
        Time.timeScale = 0f;
        winMenu.SetActive(true);
    }


    public void Hint(){
        SuperHint.SetActive(true);
    }
    public void HintClose(){
        SuperHint.SetActive(false);
    }


    public void SetMainVolume(float value){
        MainAudio.SetFloat("MainVolume", value);
    }
    public void SetOtherVolume(float value){
        OtherAudio.SetFloat("OtherVolume", value);
    }

    
}
