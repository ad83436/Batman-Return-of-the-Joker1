using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;
using UnityEngine;

public class NPC : HealthandDeath
{
 
    public Batman Dark_Knight;
    public Vector2 Direction;
    public float Distance;
    public static bool isFiring;

   
    private void Start()
    {
        isFiring = false;
        
        Dark_Knight = GameObject.FindWithTag("Batman").GetComponent<Batman>();
    }
    private void Update()
    {
        Direction = this.gameObject.transform.position - Dark_Knight.transform.position;
        Distance = Mathf.Sqrt(Mathf.Pow(Direction.x, 2));
    }

    public virtual void Movement()
    {
        
    }
    public virtual void Spawn()
    {
        
    }
    

}
    
