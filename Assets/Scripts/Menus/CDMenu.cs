using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CDMenu : MonoBehaviour
{
    public bool timerOver;
    [Range(0,1)]
    public float mVolume;
    [Range(0,1)]
    public float eVolume;
    // Start is called before the first frame update
    public void Start()
    {
        mVolume = PlayerPrefs.GetFloat("MusicVolume");
        eVolume = PlayerPrefs.GetFloat("soundEffects");

    }

    // Update is called once per frame
    public void Update()
    {

        StartGame();
      
        NoiseManager.instance.musicVolume = mVolume;
        NoiseManager.instance.SoundEffectVolume = eVolume;
    }

    public void TimeIsUp()
    {
        timerOver = true;
    }

    public void CountDownSound()
    {
        NoiseManager.instance.PlaySound("CountDown");
    }

    public void StartGame()
    {
        if (!timerOver)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                SceneManager.LoadScene("Stage_1-2");
                HealthandDeath.theBatLives = 3;
            }
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
