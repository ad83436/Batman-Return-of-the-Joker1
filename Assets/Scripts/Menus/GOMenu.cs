using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GOMenu : MonoBehaviour
{
    public Rigidbody2D gameOver;
    public float timerToMM = 0;
    public float y;
    public bool hitblock;

    [Range(0, 1)]
    public float mVolume;
    [Range(0, 1)]
    public float eVolume;

    // Start is called before the first frame update
    public void Start()
    {
        mVolume = PlayerPrefs.GetFloat("MusicVolume");
        eVolume = PlayerPrefs.GetFloat("soundEffects");

        gameOver = GameObject.FindWithTag("GOText").GetComponent<Rigidbody2D>();
        NoiseManager.instance.PlaySound("GameOver");
  
    }

    // Update is called once per frame
    public void Update()
    {
        NoiseManager.instance.musicVolume = mVolume;
        NoiseManager.instance.SoundEffectVolume = eVolume;

        MoveGOver();
    }

    public void MoveGOver()
    {
        timerToMM += Time.deltaTime;
        if (!hitblock)
        {
            gameOver.velocity = new Vector2(0.0f, y);
        }
        else
        {
            gameOver.velocity = Vector2.zero;
        }

        if(timerToMM >= 8)
        {
            SceneManager.LoadScene("GameMenu");

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blocker")
        {
            hitblock = true;
        }
    }
}
