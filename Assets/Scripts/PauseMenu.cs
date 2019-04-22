using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausedUI;
    public static PauseMenu VolumeLevel;
    public static bool Paused = false;
    public Slider musicVolume;
    public Slider soundEffectsVolume;
    public Button Resumes;
    public Button Volume;
    public Button Back;
    public Button Quit;
    public Toggle Mute;

    public void Start()
    {
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        soundEffectsVolume.value = PlayerPrefs.GetFloat("soundEffects");
    }

    // Update is called once per frame
    public void Update()
    {
        Pause();
        isMute();
        NoiseManager.instance.musicVolume = musicVolume.value;
        NoiseManager.instance.SoundEffectVolume = soundEffectsVolume.value;
    }

    public void Pause()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Paused)
            {
                Resume();
                GoBack();
            }

            else
            {
                GamePaused();
            }
        }
    }

    public void VolumeButtonClicked()
    {
        musicVolume.gameObject.SetActive(true);
        soundEffectsVolume.gameObject.SetActive(true);
        Resumes.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        Volume.gameObject.SetActive(false);
        Back.gameObject.SetActive(true);
        Mute.gameObject.SetActive(true);

    }

    public void Resume()
    {
        PausedUI.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }


    void GamePaused()
    {
        PausedUI.SetActive(true);
        Time.timeScale = 0;
        Paused = true;
    }

    public void GoBack()
    {
        musicVolume.gameObject.SetActive(false);
        soundEffectsVolume.gameObject.SetActive(false);
        Resumes.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        Volume.gameObject.SetActive(true);
        Back.gameObject.SetActive(false);
        Mute.gameObject.SetActive(false);
    }

    public void isMute()
    {
        if (Mute.isOn)
        {
            musicVolume.value = 0.0f;
            soundEffectsVolume.value = 0.0f;
            musicVolume.enabled = false;
            soundEffectsVolume.enabled = false;
        }

        else
        {
            musicVolume.enabled = true;
            soundEffectsVolume.enabled = true;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit the Game");
        Application.Quit();
    }
}
