using UnityEngine;
using System.Collections.Generic;


public class JumpEnemy : NPC
{
    Animator jAnimaitons;
    Animator jAnimaitons1;
    public NPC jumpEnemy;
    public NPC jumpEnemy1;
    public float jumpHeight;
    bool shootNow = false;
    bool jumpEnemyIsShooting = false;
    public bool jumppedAttacked = false;

    void Start()
    {
        jumpEnemy = GameObject.FindWithTag("JumpMan").GetComponent<NPC>();
        jAnimaitons = GameObject.FindWithTag("JumpMan").GetComponent<Animator>();
        jAnimaitons1 = GameObject.FindWithTag("JumpMan1").GetComponent<Animator>();
        jumpEnemy1 = GameObject.FindWithTag("JumpMan1").GetComponent<NPC>();
        jAnimaitons.SetBool("OnFloor", false);
    }

    void FixedUpdate()
    {

        if (jumpEnemy.canAttack)
        {
            jumpEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(jumpEnemy.GetComponent<Rigidbody2D>().velocity.x, jumpEnemy.GetComponent<Rigidbody2D>().velocity.x);
        }
        Death();
        Spawn();
        NpcShot();
        Movement();
    }

    public override void Spawn()
    {
        if (jumpEnemy.Distance > 120)
        {
            jumpEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            jumpEnemy.GetComponent<SpriteRenderer>().enabled = false;
            jumpEnemy.GetComponent<BoxCollider2D>().enabled = false;
        }

        else if (jumpEnemy.Distance < 120)
        {
            jumpEnemy.GetComponent<SpriteRenderer>().enabled = true;
            jumpEnemy.GetComponent<BoxCollider2D>().enabled = true;

            if (jumpEnemy.touchedFloor == false)
            {
                jumpEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -175.0f);
            }
        }

        if (jumpEnemy1.Distance > 120)
        {
            jumpEnemy1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            jumpEnemy1.GetComponent<SpriteRenderer>().enabled = false;
            jumpEnemy1.GetComponent<BoxCollider2D>().enabled = false;
        }

        else if (jumpEnemy1.Distance < 120)
        {
            jumpEnemy1.GetComponent<SpriteRenderer>().enabled = true;
            jumpEnemy1.GetComponent<BoxCollider2D>().enabled = true;

            if ( jumpEnemy1.touchedFloor == false)
            {
                jumpEnemy1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -175.0f);
            }
        }
    }

    public override void Death()
    {
        base.Death();

    }

    public override void Movement()
    {
       
       if (jumpEnemy.Distance < 58 && jumpEnemy.Distance > 30)
        {
            jumpEnemy.waitToAttackTimer += Time.fixedDeltaTime;

            if (jumpEnemy.touchedFloor)
            {
                jumpEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                jumpEnemy.canAttack = true;
                jumpEnemy.waitToAttackTimer = 0.0f;
                jumpEnemy.jumpTimer = 0.0f; 
            }

            if (jumpEnemy.canAttack)
            {
                jumpEnemy.jumpTimer += Time.fixedDeltaTime;
                jumpEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-jumpEnemy.Direction.x, jumpHeight);
            }
        }
        else if (jumpEnemy.Distance > 58.0f)
        {
            jumpEnemy.canAttack = false;
            jumpEnemy.jumpTimer = 0.0f;
        }

        if (jumpEnemy1.Distance < 58 && jumpEnemy1.Distance > 30 && jAnimaitons1.GetBool("OnFoor1") == true)
        {
            jumpEnemy1.jumpTimer += Time.deltaTime;
            jumpEnemy1.GetComponent<Rigidbody2D>().velocity = new Vector2(jumpEnemy1.Direction.x, jumpHeight); 
        }

        if (jumpEnemy1.jumpTimer > 1.5)
        {
            jumpEnemy1.jumpTimer = 0;
        }
    }

    public override void NpcShot()
    {
        GameObject bulletInstance;
        GameObject bulletInstance1;
        GameObject flashInstance;
        GameObject flashInstance1;
        ////fix//// after the jump Enemy falls from the sky  his first shots come too fast find a way to delay the first shots on a later day. make the npc always face theBats.
        //// issue is that the time still goes while shooting if the gun is firing then the timer should stay at zero come back to fix this issue.
        ///////fix pivoit on the shooting animations the shooter move +x while shooting.


        if (jumpEnemy.Distance < 120 && jumpEnemy.Distance > 58 && jAnimaitons.GetBool("OnFloor") == true )
        {
                jumpEnemy.timeTillNextShots += Time.fixedDeltaTime;

                if (jumpEnemy.timeTillNextShots > 0.5f && jumpEnemy.timeTillNextShots < 2)
                {
                    jAnimaitons.SetBool("isShooting", true);
                }

                if (jumpEnemy.timeTillNextShots > 2)
                {
                    jumpEnemy.timeTillNextShot += Time.fixedDeltaTime;
                    if (Time.time > jumpEnemy.nextFire)
                    {
                        jumpEnemy.nextFire = Time.time + jumpEnemy.fireRate;

                        if (jumpEnemy.isShooting)
                        {
                            jumpEnemy.Flash.transform.position = jumpEnemy.GetComponent<Rigidbody2D>().position + new Vector2(-23.0f, -12.5f);
                            jumpEnemy.Bullets[0].transform.position = jumpEnemy.GetComponent<Rigidbody2D>().position + new Vector2(-21.0f, -12.5f);
                            bulletInstance = Instantiate(jumpEnemy.Bullets[0], jumpEnemy.Bullets[0].transform.position, jumpEnemy.Bullets[0].transform.rotation);
                            flashInstance = Instantiate(jumpEnemy.Flash, jumpEnemy.Flash.transform.position, jumpEnemy.Flash.transform.rotation);
                            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                            Destroy(bulletInstance, 1);
                            Destroy(flashInstance, jumpEnemy.destroyFlash);
                        }
                       
                        if (jumpEnemy.timeTillNextShot >= 0.15f)
                        {
                            jumpEnemy.isShooting = false;
                        }

                        if (jumpEnemy.timeTillNextShots > 5)
                        {
                            jumpEnemy.timeTillNextShot = 0.0f;
                            jumpEnemy.timeTillNextShots = 0.0f;
                        }

                        if (jumpEnemy.isShooting == false)
                        {
                            jAnimaitons.SetBool("isShooting", false);
                        }

                    }
                }
        }

        
        
        else if (jumpEnemy.Distance < 58 || jumpEnemy.Distance > 120)
        {
            jAnimaitons.SetBool("isShooting", false);
            jumpEnemy.timeTillNextShots = 0.0f;
            jumpEnemy.timeTillNextShot = 0.0f;
        }

        if (jumpEnemy1.Distance < 120 && jumpEnemy1.Distance > 58 && jAnimaitons1.GetBool("OnFloor1") == true)
        {
            jumpEnemy1.timeTillNextShots += Time.fixedDeltaTime;

            if (jumpEnemy1.timeTillNextShots > 0.5f && jumpEnemy1.timeTillNextShots < 1)
            {
                jAnimaitons1.SetBool("isShooting1", true);
            }

            if (jumpEnemy1.timeTillNextShots > 1)
            {
                jumpEnemy1.timeTillNextShot += Time.fixedDeltaTime;
                if (Time.time > jumpEnemy1.nextFire)
                {
                    nextFire = Time.time + jumpEnemy1.fireRate;

                    if (jumpEnemy1.isShooting)
                    {
                        jumpEnemy1.Flash.transform.position = jumpEnemy1.GetComponent<Rigidbody2D>().position + new Vector2(-23.0f, -12.5f);
                        jumpEnemy1.Bullets[0].transform.position = jumpEnemy1.GetComponent<Rigidbody2D>().position + new Vector2(-21.0f, -12.5f);
                        bulletInstance1 = Instantiate(Bullets[0], Bullets[0].transform.position, Bullets[0].transform.rotation);
                        flashInstance1 = Instantiate(Flash, Flash.transform.position, Flash.transform.rotation);
                        bulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                        Destroy(bulletInstance1, 1);
                        Destroy(flashInstance1, jumpEnemy1.destroyFlash);
                    }

                    if (jumpEnemy1.timeTillNextShot >= 0.15f)
                    {
                        
                        jumpEnemy1.isShooting = false;
                    }

                    if (jumpEnemy1.timeTillNextShots > 5)
                    {
                        jumpEnemy1.timeTillNextShot = 0.0f;
                        jumpEnemy1.timeTillNextShots = 0.0f;
                    }

                    if (jumpEnemy1.isShooting == false)
                    {
                        jAnimaitons1.SetBool("isShooting1", false);
                    }

                }
            }
        }

        else if (jumpEnemy1.Distance < 58 || jumpEnemy1.Distance > 120)
            {
                jAnimaitons1.SetBool("isShooting1", false);
               jumpEnemy1.timeTillNextShots = 0.0f;
               jumpEnemy1.timeTillNextShot = 0.0f;
            }
    }
    
    public void jumpEnemyShooting()
    {
        jumpEnemy.isShooting = true;
    }

    public void jumpEnemyShooting1()
    {
        jumpEnemy1.isShooting = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Batman" && gameObject.tag == "JumpMan")
        {
            theBats.maxHealth -= jumpEnemy.theDamage;
            
            Debug.Log("You hit me bro");
        }

        if (collision.gameObject.tag == "GenericBullet")
        {
            jumpEnemy.maxHealth -= 1;
            jumpEnemy1.maxHealth -= 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Floor" && gameObject.tag == "JumpMan")
        {
            
            jumpEnemy.touchedFloor = true;
            jumpEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            jAnimaitons.SetBool("OnFloor", true);
            
            Debug.Log("Touched th floor");
        }

        if (collision.gameObject.tag == "Floor" && gameObject.tag == "JumpMan1")
        {
            jAnimaitons1.SetBool("OnFloor1", true);
            jumpEnemy1.touchedFloor = true;

            jumpEnemy1.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }

        if(collision.gameObject.tag == "GenericBullet" && gameObject.tag == "jumpMan")
        {
            Destroy(jumpEnemy);
            Destroy(collision.gameObject);
        }

    }
}


