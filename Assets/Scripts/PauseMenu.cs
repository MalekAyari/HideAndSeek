using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;

    public void setMasterVolume(){
        float volume = Mathf.Log10(masterSlider.value)*20;
        if (GameManager.instance != null) {
            GameManager.instance.audioVolumes[0] = masterSlider.value;
        }

        audioMixer.SetFloat("Master", volume);
    }
    
    public void setMusicVolume(){
        float volume = Mathf.Log10(musicSlider.value)*20;
        if (GameManager.instance != null) {
            GameManager.instance.audioVolumes[1] = musicSlider.value;
        }

        audioMixer.SetFloat("Music", volume);
    }

    public void setEffectsVolume(){
        float volume = Mathf.Log10(effectsSlider.value)*20;
                if (GameManager.instance != null) {
            GameManager.instance.audioVolumes[2] = effectsSlider.value;
        }

        Debug.Log("set volume " + volume);
        audioMixer.SetFloat("Effects", volume);
    }

    public void Start(){
        setMasterVolume();
        setMusicVolume();
        setEffectsVolume();
    }
    
    public void Open(GameObject pause){
        pause.SetActive(true);
        masterSlider.value = GameManager.instance.audioVolumes[0];
        musicSlider.value = GameManager.instance.audioVolumes[1];
        effectsSlider.value = GameManager.instance.audioVolumes[2];

        Time.timeScale = 0f;
    }

    public void Resume(GameObject pause){
        pause.SetActive(false);
        Time.timeScale = 1f;

        GameManager.instance.Save();
    }

    public void Exit(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");

        GameManager.instance.Save();
    }


}
