using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;

using UnityEngine;

public class NPC : HealthandDeath
{
    public Batman theBats;
    public Vector2 Direction;
    public float Distance;
    public GameObject[] Bullets;
    public GameObject Flash;
    public float angle;
    public float destroyFlash;
    public float timeTillNextShot = 0.0f;
    public float timeTillNextShots = 0.0f;
    public float jumpTimer = 0.0f;
    public bool touchedFloor = false;
    public bool isShooting = false;
    public  bool thisTurned = false;
    public float nextFire;
    public float fireRate;
    public bool canAttack = false;
    public Vector2 enemyCurrentPos; 
    public float waitToAttackTimer = 0.0f;

    private void Start()
    {
        
        Bullets = new GameObject[3];
        timeTillNextShot = 0.0f;
        Bullets[0] = GameObject.FindWithTag("JBULLETS").GetComponent<GameObject>();
        Bullets[1] = GameObject.FindWithTag("Knife").GetComponent<GameObject>();
        Bullets[2] = GameObject.FindWithTag("BoltAttack").GetComponent<GameObject>();
        timeTillNextShots = 0.0f;
        Flash = GameObject.FindWithTag("MuzzleFlash").GetComponent<GameObject>();
        theBats = GameObject.FindWithTag("Batman").GetComponent<Batman>();
    }
    public void Update()
    {
        FacePlayer();
        Direction = gameObject.transform.position - theBats.transform.position;
        Distance = Mathf.Sqrt(Mathf.Pow(Direction.x, 2));
        angle = Vector2.Angle(transform.right, Direction);
    }
    
   
   

    public virtual void Movement()
    {
       
        
    }

    public virtual void Spawn()
    {
        
    }

    public virtual void NpcShot()
    {
        
      
     
    }
    
    public virtual void FacePlayer()
    {
        if (Mathf.Abs(angle) < 90.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            thisTurned = false;
        }
        if (Mathf.Abs(angle) > 90.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            thisTurned = true;
        }
    }

       
}
    
