using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatmanHealthBar : HealthandDeath
{
    public SpriteRenderer[] HealthBars;
    public SpriteRenderer[] Lives;
    public static int healthBars;

    public HealthandDeath theBatsHealth;
    // Start is called before the first frame update
    void Start()
    {
        HealthBars = new SpriteRenderer[8];
        Lives = new SpriteRenderer[3];
        theBatsHealth = GameObject.FindWithTag("Batman").GetComponent<HealthandDeath>();
        HealthBars[0] = GameObject.FindWithTag("LifePoint").GetComponent<SpriteRenderer>();
        HealthBars[1] = GameObject.FindWithTag("LifePoint1").GetComponent<SpriteRenderer>();
        HealthBars[2] = GameObject.FindWithTag("LifePoint2").GetComponent<SpriteRenderer>();
        HealthBars[3] = GameObject.FindWithTag("LifePoint3").GetComponent<SpriteRenderer>();
        HealthBars[4] = GameObject.FindWithTag("LifePoint4").GetComponent<SpriteRenderer>();
        HealthBars[5] = GameObject.FindWithTag("LifePoint5").GetComponent<SpriteRenderer>();
        HealthBars[6] = GameObject.FindWithTag("LifePoint6").GetComponent<SpriteRenderer>();
        HealthBars[7] = GameObject.FindWithTag("LifePoint7").GetComponent<SpriteRenderer>();
        Lives[0] = GameObject.FindWithTag("Lives").GetComponent<SpriteRenderer>();
        Lives[1] = GameObject.FindWithTag("Lives1").GetComponent<SpriteRenderer>();
        Lives[2] = GameObject.FindWithTag("Lives2").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theBatsHealth.maxHealth > 8)
        {
            theBatsHealth.maxHealth = 8;
        }

        switch (theBatsHealth.maxHealth)
        {
            case 8:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = true;
                HealthBars[2].enabled = true;
                HealthBars[3].enabled = true;
                HealthBars[4].enabled = true;
                HealthBars[5].enabled = true;
                HealthBars[6].enabled = true;
                HealthBars[7].enabled = true;
                break;

            case 7:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = true;
                HealthBars[2].enabled = true;
                HealthBars[3].enabled = true;
                HealthBars[4].enabled = true;
                HealthBars[5].enabled = true;
                HealthBars[6].enabled = true;
                HealthBars[7].enabled = false;
                break;

            case 6:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = true;
                HealthBars[2].enabled = true;
                HealthBars[3].enabled = true;
                HealthBars[4].enabled = true;
                HealthBars[5].enabled = true;
                HealthBars[6].enabled = false;
                HealthBars[7].enabled = false;
                break;

            case 5:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = true;
                HealthBars[2].enabled = true;
                HealthBars[3].enabled = true;
                HealthBars[4].enabled = true;
                HealthBars[5].enabled = false;
                HealthBars[6].enabled = false;
                HealthBars[7].enabled = false;
                break;

            case 4:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = true;
                HealthBars[2].enabled = true;
                HealthBars[3].enabled = true;
                HealthBars[4].enabled = false;
                HealthBars[5].enabled = false;
                HealthBars[6].enabled = false;
                HealthBars[7].enabled = false;
                break;

            case 3:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = true;
                HealthBars[2].enabled = true;
                HealthBars[3].enabled = false;
                HealthBars[4].enabled = false;
                HealthBars[5].enabled = false;
                HealthBars[6].enabled = false;
                HealthBars[7].enabled = false;
                break;

            case 2:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = true;
                HealthBars[2].enabled = false;
                HealthBars[3].enabled = false;
                HealthBars[4].enabled = false;
                HealthBars[5].enabled = false;
                HealthBars[6].enabled = false;
                HealthBars[7].enabled = false;
                break;

            case 1:
                HealthBars[0].enabled = true;
                HealthBars[1].enabled = false;
                HealthBars[2].enabled = false;
                HealthBars[3].enabled = false;
                HealthBars[4].enabled = false;
                HealthBars[5].enabled = false;
                HealthBars[6].enabled = false;
                HealthBars[7].enabled = false;
                break;

            case 0:
                HealthBars[0].enabled = false;
                HealthBars[1].enabled = false;
                HealthBars[2].enabled = false;
                HealthBars[3].enabled = false;
                HealthBars[4].enabled = false;
                HealthBars[5].enabled = false;
                HealthBars[6].enabled = false;
                HealthBars[7].enabled = false;
                break;
        }

        if(theBatLives > 3)
        {
            theBatLives = 3;
        }
        switch (theBatLives)
        {
            case 3:
                Lives[0].enabled = true;
                Lives[1].enabled = true;
                Lives[2].enabled = true;
                break;

            case 2:
                Lives[0].enabled = true;
                Lives[1].enabled = true;
                Lives[2].enabled = false;
                break;

            case 1:
                Lives[0].enabled = true;
                Lives[1].enabled = false;
                Lives[2].enabled = false;
                break;

            case 0:
                Lives[0].enabled = false;
                Lives[1].enabled = false;
                Lives[2].enabled = false;
                break;
        }
    }
}
