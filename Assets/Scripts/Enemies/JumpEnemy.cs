using UnityEngine;
using System.Collections.Generic;


public class JumpEnemy : NPC
{

    void Start()
    {
        NPC.Enemy.Add(this);
        enemyAnimator.SetBool("OnFloor", false);
    }

    void FixedUpdate()
    {
        NpcShot();
        GetDirection(theBats, Enemy);
        GetDistance(Direction);
        GetAngle(Direction);
        Death();
        Spawn();
        Movement();
    }

    public override void Spawn()
    {
        if (xDistance > 120)
        {
            enemyRb.velocity = new Vector2(0.0f, 0.0f);
            enemySprite.enabled = false;
            enemyCollider.enabled = false;
        }

        else if (xDistance < 120)
        {
          enemySprite.enabled = true;
            enemyCollider.enabled = true;

            if (!touchedFloor)
            {
                enemyRb.velocity = new Vector2(0.0f, -175.0f);
            }
        }

        if (xDistance > 120)
        {
            enemyRb.velocity = new Vector2(0.0f, 0.0f);
            enemySprite.enabled = false;
            enemyCollider.enabled = false;
        }

        else if (xDistance < 120)
        {
            enemySprite.enabled = true;
            enemyCollider.enabled = true;

            if (!touchedFloor)
            {
                enemyRb.velocity = new Vector2(0.0f, -175.0f);
            }
        }
    }

    public override void Death()
    {
        base.Death();

    }

    public override void Movement()
    {
       
    }

    public override void NpcShot()
    {
        GameObject bulletInstance;
        GameObject flashInstance;
        
        ////fix//// after the jump Enemy falls from the sky  his first shots come too fast find a way to delay the first shots on a later day. make the npc always face theBats.
        //// issue is that the time still goes while shooting if the gun is firing then the timer should stay at zero come back to fix this issue.
        ///////fix pivoit on the shooting animations the shooter move +x while shooting.

        if (xDistance < 120 && xDistance > 58 && enemyAnimator.GetBool("OnFloor"))
        {
            timeTillNextShots += Time.fixedDeltaTime;

            if (timeTillNextShots > 0.5f && timeTillNextShots < 2)
            {
                enemyAnimator.SetBool("isShooting", true);
            }

            if (timeTillNextShots > 2)
            {
                timeTillNextShot += Time.fixedDeltaTime;
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;

                    if (isShooting)
                    {
                        Flash.transform.position = enemyRb.position + new Vector2(-23.0f, -12.5f);
                        Bullets[0].transform.position = enemyRb.position + new Vector2(-21.0f, -12.5f);
                        bulletInstance = Instantiate(Bullets[0], Bullets[0].transform.position, Bullets[0].transform.rotation);
                        flashInstance = Instantiate(Flash, Flash.transform.position, Flash.transform.rotation);
                        bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                        Destroy(bulletInstance, 1);
                        Destroy(flashInstance, destroyFlash);
                    }

                    if (timeTillNextShot >= 0.15f)
                    {
                        isShooting = false;
                    }

                    if (timeTillNextShots > 5)
                    {
                        timeTillNextShot = 0.0f;
                        timeTillNextShots = 0.0f;
                    }

                    if (isShooting == false)
                    {
                        enemyAnimator.SetBool("isShooting", false);
                    }

                }
            }
        }

        else if (xDistance < 58 || xDistance > 120)
        {
            enemyAnimator.SetBool("isShooting", false);
            timeTillNextShots = 0.0f;
            timeTillNextShot = 0.0f;
        }
    }
    
    public void jumpEnemyShooting()
    {
        isShooting = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Batman")
        {
            theBats.maxHealth -= enemyHealth.theDamage;
            Debug.Log("You hit me bro");
        }

        if(collision.gameObject.tag == "Batman" && gameObject.tag == "Knife")
        {

        }

        if (collision.gameObject.tag == "GenericBullet")
        {
            enemyHealth.maxHealth -= 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Floor")
        {
            touchedFloor = true;
            enemyRb.velocity = new Vector2(0.0f, 0.0f);
            enemyAnimator.SetBool("OnFloor", true);
            Debug.Log("Touched th floor");
        }
    }
}


