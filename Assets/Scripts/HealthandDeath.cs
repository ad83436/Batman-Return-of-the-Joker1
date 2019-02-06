using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthandDeath : MonoBehaviour
{
    public int maxHealth;
    public int theDamage;
    

    
    void Start()
    {
        
    }
    public virtual void dealDamage(){
        
    }
   
    public virtual void Death()
    {
       if (gameObject.GetComponent<HealthandDeath>().maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
