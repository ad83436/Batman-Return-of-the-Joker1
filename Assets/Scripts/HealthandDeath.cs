using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthandDeath : MonoBehaviour
{
    public float maxHealth;
    public float theDamage;


    public bool IsHitForHealthBar;
   
    void Start()
    {
        
    }

    public virtual void Death()
    {
       if (this.gameObject.GetComponent<HealthandDeath>().maxHealth <= 0)
       {
            Destroy(this.gameObject);
       }
    }
}
