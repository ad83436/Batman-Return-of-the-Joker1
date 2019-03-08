using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatmanHealthBar : HealthandDeath
{
    public SpriteRenderer HealthBars, HealthBars1, HealthBars2, HealthBars3, HealthBars4, HealthBars5, HealthBars6, HealthBars7;
    public static int healthBars;

    public HealthandDeath theBatsHealth;
    // Start is called before the first frame update
    void Start()
    {
        theBatsHealth = GameObject.FindWithTag("Batman").GetComponent<HealthandDeath>();
        HealthBars = GameObject.FindWithTag("LifePoint").GetComponent<SpriteRenderer>();
        HealthBars1 = GameObject.FindWithTag("LifePoint1").GetComponent<SpriteRenderer>();
        HealthBars2 = GameObject.FindWithTag("LifePoint2").GetComponent<SpriteRenderer>();
        HealthBars3 = GameObject.FindWithTag("LifePoint3").GetComponent<SpriteRenderer>();
        HealthBars4 = GameObject.FindWithTag("LifePoint4").GetComponent<SpriteRenderer>();
        HealthBars5 = GameObject.FindWithTag("LifePoint5").GetComponent<SpriteRenderer>();
        HealthBars6 = GameObject.FindWithTag("LifePoint6").GetComponent<SpriteRenderer>();
        HealthBars7 = GameObject.FindWithTag("LifePoint7").GetComponent<SpriteRenderer>();
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
                HealthBars.enabled = true;
                HealthBars1.enabled = true;
                HealthBars2.enabled = true;
                HealthBars3.enabled = true;
                HealthBars4.enabled = true;
                HealthBars5.enabled = true;
                HealthBars6.enabled = true;
                HealthBars7.enabled = true;
                break;

            case 7:
                HealthBars.enabled = true;
                HealthBars1.enabled = true;
                HealthBars2.enabled = true;
                HealthBars3.enabled = true;
                HealthBars4.enabled = true;
                HealthBars5.enabled = true;
                HealthBars6.enabled = true;
                HealthBars7.enabled = false;
                break;

            case 6:
                HealthBars.enabled = true;
                HealthBars1.enabled = true;
                HealthBars2.enabled = true;
                HealthBars3.enabled = true;
                HealthBars4.enabled = true;
                HealthBars5.enabled = true;
                HealthBars6.enabled = false;
                HealthBars7.enabled = false;
                break;

            case 5:
                HealthBars.enabled = true;
                HealthBars1.enabled = true;
                HealthBars2.enabled = true;
                HealthBars3.enabled = true;
                HealthBars4.enabled = true;
                HealthBars5.enabled = false;
                HealthBars6.enabled = false;
                HealthBars7.enabled = false;
                break;

            case 4:
                HealthBars.enabled = true;
                HealthBars1.enabled = true;
                HealthBars2.enabled = true;
                HealthBars3.enabled = true;
                HealthBars4.enabled = false;
                HealthBars5.enabled = false;
                HealthBars6.enabled = false;
                HealthBars7.enabled = false;
                break;

            case 3:
                HealthBars.enabled = true;
                HealthBars1.enabled = true;
                HealthBars2.enabled = true;
                HealthBars3.enabled = false;
                HealthBars4.enabled = false;
                HealthBars5.enabled = false;
                HealthBars6.enabled = false;
                HealthBars7.enabled = false;
                break;

            case 2:
                HealthBars.enabled = true;
                HealthBars1.enabled = true;
                HealthBars2.enabled = false;
                HealthBars3.enabled = false;
                HealthBars4.enabled = false;
                HealthBars5.enabled = false;
                HealthBars6.enabled = false;
                HealthBars7.enabled = false;
                break;

            case 1:
                HealthBars.enabled = true;
                HealthBars1.enabled = false;
                HealthBars2.enabled = false;
                HealthBars3.enabled = false;
                HealthBars4.enabled = false;
                HealthBars5.enabled = false;
                HealthBars6.enabled = false;
                HealthBars7.enabled = false;
                break;

            case 0:
                HealthBars.enabled = false;
                HealthBars1.enabled = false;
                HealthBars2.enabled = false;
                HealthBars3.enabled = false;
                HealthBars4.enabled = false;
                HealthBars5.enabled = false;
                HealthBars6.enabled = false;
                HealthBars7.enabled = false;
                break;

        }
    }

    public void RemoverHealthPoint()
    {
        

        
    }
}
