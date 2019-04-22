using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;
using UnityEngine;

public abstract class NPC : HealthandDeath
{
    public Batman theBats;
    public Vector2 Direction;
    public float xDistance;
    public float yDistance;
    public GameObject[] Bullets;
    public GameObject Flash;
    public static List<NPC> Enemy = new List<NPC>();
    public SpriteRenderer enemySprite;
    public Rigidbody2D enemyRb;
    public HealthandDeath enemyHealth;
    public Animator enemyAnimator;
    public BoxCollider2D enemyCollider;
    public float angle; 
    public float destroyFlash;
    public float timeTillNextShot = 0.0f;
    public float timeTillNextShots = 0.0f;
    public float jumpTimer = 0.0f;
    public bool touchedFloor = false;
    public bool isShooting = false;
    public  bool thisTurned = false;
    public float nextFire;
    public float jumpHeight;
    public bool shootNow = false;
    public bool jumpEnemyIsShooting = false;
    public bool jumppedAttacked = false;
    public float fireRate;
    public bool canAttack = false;
    public Vector2 enemyCurrentPos; 
    public float waitToAttackTimer = 0.0f;
    public  bool isHit;

    private void Start()
    { 
        Bullets = new GameObject[3];
        timeTillNextShot = 0.0f;
        Bullets[0] = GameObject.FindWithTag("JBULLETS").GetComponent<GameObject>();
        Bullets[1] = GameObject.FindWithTag("Knife").GetComponent<GameObject>();
        Bullets[2] = GameObject.FindWithTag("BoltAttack").GetComponent<GameObject>();
        timeTillNextShots = 0.0f;
        Flash = GameObject.FindWithTag("MuzzleFlash").GetComponent<GameObject>();
    }

    public void Update()
    {
        if(maxHealth <= 0)
        {
            NoiseManager.instance.PlaySound("EnemyDeath");
            Death();
        }
    }

    public Vector2 GetDirection(Batman Player, List<NPC> Enemy)
    {
        return Direction = Player.transform.position - transform.position;
    }

    public void GetDistance(Vector2 Direction_)
    {
        xDistance = Mathf.Sqrt(Mathf.Pow(Direction_.x, 2));
        yDistance = Mathf.Sqrt(Mathf.Pow(Direction_.y, 2));
    }

    public void GetAngle(Vector2 Direction_)
    {
        angle = Vector2.Angle(transform.right, Direction_);
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
        if (Mathf.Abs(angle) > 90.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            thisTurned = false;
        }
        if (Mathf.Abs(angle) < 90.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            thisTurned = true;
        }
    }

    public void OnStartUp()
    {
        for(int i =0; i < Enemy.Count; ++i)
        {
            enemySprite = Enemy[i].GetComponent<SpriteRenderer>();
            enemyRb = Enemy[i].GetComponent<Rigidbody2D>();
            enemyHealth = Enemy[i].GetComponent<HealthandDeath>();
            enemyAnimator = Enemy[i].GetComponent<Animator>();
            enemyCollider = Enemy[i].GetComponent<BoxCollider2D>();
        }
    }

    public void takeDamage()
    {
        NoiseManager.instance.PlaySound("EnemyHit");
        maxHealth -= theBats.theDamage;
    }

    public void OnDestroy()
    {
        Enemy.Remove(this);
    }


}
    
