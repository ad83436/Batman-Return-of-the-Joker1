using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MMenuButton : MonoBehaviour
{
    public Button newGame;
    public Button Settings;
    public Button Backs;
    public Slider musicVolume;
    public Slider soundEffectsVolume;
    public SpriteRenderer[] Volume = new SpriteRenderer[4];
    public  bool settingsMenu;

    // Start is called before the first frame update
    public void Start()
    {
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        soundEffectsVolume.value = PlayerPrefs.GetFloat("soundEffects");
    }

    // Update is called once per frame
    public void Update()
    {
       NoiseManager.instance.musicVolume = musicVolume.value;
       NoiseManager.instance.SoundEffectVolume = soundEffectsVolume.value;
        for (int i = 0; i < Volume.Length; ++i)
        {
            if (settingsMenu)
            {
                Volume[i].enabled = true;
            }
            
            else
            {
                Volume[i].enabled = false;
            }
        }
    }

    public void StartGame()
    {
        if (MainMenu.renderDone)
        {
            SceneManager.LoadScene("Stage_1-2");
            HealthandDeath.theBatLives = 3;
        }
    }

    public void Stttings()
    {
        musicVolume.gameObject.SetActive(true);
        soundEffectsVolume.gameObject.SetActive(true);
        Backs.gameObject.SetActive(true);
        newGame.gameObject.SetActive(false);
        Settings.gameObject.SetActive(false);
        settingsMenu = true;
    }


    public void Back()
    {
        musicVolume.gameObject.SetActive(false);
        soundEffectsVolume.gameObject.SetActive(false);
        Backs.gameObject.SetActive(false);
        newGame.gameObject.SetActive(true);
        Settings.gameObject.SetActive(true);
        settingsMenu = false;
    }
}
