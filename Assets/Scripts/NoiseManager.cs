using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NoiseManager : MonoBehaviour
{
    //instance
    public static NoiseManager instance = null;

    //Sources
    public AudioSource theBatSoundEffectsSource;
    public AudioSource mainSource;
    public AudioSource introSource;
    public AudioSource mainMenuSource;
    public AudioSource enemySoundEffectsSource;
    public AudioSource GOSource;
    public AudioSource CDSource;
    //clips
    public AudioClip[] sounds = new AudioClip[13];

    //variables
    public bool playedSounds;

    [Range(0, 1)]
    public float musicVolume;

    [Range(0, 1)]
    public float SoundEffectVolume;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
       
        sounds[0].name = "Intro";
        sounds[1].name = "MainLoop";
        sounds[2].name = "MainMenuMusic";
        sounds[3].name = "BatJumpSound";
        sounds[4].name = "BatmanHit";
        sounds[5].name = "BatmanDeath";
        sounds[6].name = "EnemyHit";
        sounds[7].name = "EnemyDeath";
        sounds[8].name = "PowerUpCollected";
        sounds[9].name = "CountDown";
        sounds[10].name = "GameOver";
        sounds[11].name = "BatShot";
        sounds[12].name = "BallHitFloor";

        ThrowException();
    }

    public void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("soundEffects", SoundEffectVolume);
        VolumeControl();
    }

    public void PlaySound(string clipName)
    {
        if (clipName == sounds[0].name)
        {
            introSource.clip = sounds[0];
            introSource.Play();
            this.playedSounds = true;
        }
      
        else if (clipName == sounds[1].name)
        {
            mainSource.clip = sounds[1];
            mainSource.Play();
            this.playedSounds = true;
        }

        else if (clipName == sounds[2].name)
        {
            mainMenuSource.clip = sounds[2];
            mainMenuSource.Play();
            this.playedSounds = true;
        }

        else if (clipName == sounds[3].name)
        {
            theBatSoundEffectsSource.clip = sounds[3];
            theBatSoundEffectsSource.Play();
            this.playedSounds = true;
        }

        else if(clipName == sounds[4].name)
        {
            theBatSoundEffectsSource.clip = sounds[4];
            theBatSoundEffectsSource.Play();
            this.playedSounds = true;
        }

         else if(clipName == sounds[5].name)
         {
            theBatSoundEffectsSource.clip = sounds[5];
            theBatSoundEffectsSource.Play();
            this.playedSounds = true;
         }
        
        else if(clipName == sounds[6].name)
        {
            enemySoundEffectsSource.clip = sounds[6];
            enemySoundEffectsSource.Play();
            this.playedSounds = true;
        }

        else if (clipName == sounds[7].name)
        {
            enemySoundEffectsSource.clip = sounds[7];
            enemySoundEffectsSource.Play();
            this.playedSounds = true;
        }

        else if (clipName == sounds[8].name)
        {
            theBatSoundEffectsSource.clip = sounds[8];
            theBatSoundEffectsSource.Play();
            this.playedSounds = true;
        }

        else if(clipName == sounds[9].name)
        {
            CDSource.clip = sounds[9];
            CDSource.Play();
            this.playedSounds = true;
        }

        else if (clipName == sounds[10].name)
        {
            GOSource.clip = sounds[10];
            GOSource.Play();
            this.playedSounds = true;
        }
        
        else if (clipName == sounds[11].name)
        {
            theBatSoundEffectsSource.clip = sounds[11];
            theBatSoundEffectsSource.Play();
            this.playedSounds = true;
        }
        
        else if(clipName == sounds[12].name)
        {
            enemySoundEffectsSource.clip = sounds[12];
            enemySoundEffectsSource.Play();
            this.playedSounds = true;
        }

        else
        {
            this.playedSounds = false;
        }
    }

    public void VolumeControl()
    {
        mainMenuSource.volume = musicVolume;
        mainSource.volume = musicVolume;
        introSource.volume = musicVolume;
        theBatSoundEffectsSource.volume = SoundEffectVolume;
        GOSource.volume = musicVolume;
        CDSource.volume = SoundEffectVolume;
        enemySoundEffectsSource.volume = SoundEffectVolume;
    }

    void ThrowException()
    {
        if (!playedSounds)
        {    
            throw new Exception("Used Wrong string name for Play Sound Method");
        }
    }
}

