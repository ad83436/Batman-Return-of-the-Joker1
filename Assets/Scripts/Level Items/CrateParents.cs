using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateParents : HealthandDeath
{

    public Batman theBats;
    // Start is called before the first frame update
    void Start()
    {
        theBats = GameObject.FindWithTag("Batman").GetComponent<Batman>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        maxHealth -= theBats.theDamage;
    }
}
