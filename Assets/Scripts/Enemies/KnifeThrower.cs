using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : NPC
{
  
    // Start is called before the first frame update
    void Start()
    {
        NPC.Enemy.Add(this);
        OnStartUp();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        NpcShot();
        GetDirection(theBats, Enemy);
        GetDistance(Direction);
        GetAngle(Direction);
        FacePlayer();
        
    }

    public override void Movement()
    {
      
    }

    public override void NpcShot()
    {
        GameObject knifeInstance;

        if (xDistance < 100 && !thisTurned)
        {
            timeTillNextShot += Time.fixedDeltaTime;

            if (timeTillNextShot >= 4)
            {
                enemyAnimator.SetBool("inRange", true);

                if (Time.time > nextFire)
                {
                    if (canAttack)
                    {
                        Bullets[1].GetComponent<SpriteRenderer>().flipX = true;
                        nextFire = Time.time + fireRate;
                        Bullets[1].transform.position = enemyRb.position + new Vector2(-35.0f, 0.0f);
                        knifeInstance = Instantiate(Bullets[1], Bullets[1].transform.position, Bullets[1].transform.rotation);
                        knifeInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-9000.0f, 0.0f) * Time.fixedDeltaTime;
                    }
                }
            }

            if (xDistance < 100 && timeTillNextShot >= 4.5)
            {
                canAttack = false;
                timeTillNextShot = 0;
                enemyAnimator.SetBool("inRange", false);
            }
        }

        else if (xDistance < 100 && thisTurned)
        {
            timeTillNextShot += Time.fixedDeltaTime;

            if (timeTillNextShot >= 4)
            {
                enemyAnimator.SetBool("inRange", true);

                if (Time.time > nextFire)
                {
                    if (canAttack)
                    {
                        Bullets[1].GetComponent<SpriteRenderer>().flipX = false;
                        nextFire = Time.time + fireRate;
                        Bullets[1].transform.position = enemyRb.position + new Vector2(25.0f, 0.0f);
                        knifeInstance = Instantiate(Bullets[1], Bullets[1].transform.position, Bullets[1].transform.rotation);
                        knifeInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(9000.0f, 0.0f) * Time.fixedDeltaTime;
                    }
                }
            }

            if (xDistance < 100 && timeTillNextShot >= 4.5)
            {
                canAttack = false;
                timeTillNextShot = 0;
                enemyAnimator.SetBool("inRange", false);
            }

            else if (xDistance > 100)
            {
                canAttack = false;
                enemyAnimator.SetBool("inRange", false);
            }
        }
    }

    public void WhenToShoot()
    {
      canAttack = true;            
    }

    public override void FacePlayer()
    {
        base.FacePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        {
            if (collision.gameObject.tag == "Batman")
            {
                theBats.animation.SetBool("isHit", true);
                theBats.batHealth.maxHealth -= theDamage;
                Debug.Log("You hit me bro");
            }
        }

        if (collision.gameObject.tag == "GenericBullet")
        {
            isHit = true;
            takeDamage();
            Destroy(collision.gameObject);
        }
    }
}
