using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyles : NPC
{

    // Start is called before the first frame update
    void Start()
    {
        NPC.Enemy.Add(this);   
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        NpcShot();
        GetDirection(theBats, Enemy);
        GetDistance(Direction);
        GetAngle(Direction);
        if(maxHealth <= 0)
        {
            Death();
        }
    }

    public override void NpcShot()
    {
        GameObject boltInstance;
        if(xDistance > 50 && xDistance < 100  )
        {
            timeTillNextShot += Time.fixedDeltaTime;

            if(timeTillNextShot > 1.5)
            {
                if (Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    Bullets[2].transform.position = enemyRb.position + new Vector2(-11.0f, 25.0f);
                    boltInstance = Instantiate(Bullets[2], Bullets[2].transform.position,Bullets[2].transform.rotation);
                    boltInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3200.0f, 7000.0f), ForceMode2D.Impulse);
                    Destroy(boltInstance, 1);
                    timeTillNextShot = 0;
                }
            }
        }

        else if(xDistance < 50 )
        {
            timeTillNextShot += Time.fixedDeltaTime;

            if (timeTillNextShot > 1.5)
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Bullets[2].transform.position = enemyRb.position + new Vector2(-11.0f, 25.0f);
                    boltInstance = Instantiate(Bullets[2], Bullets[2].transform.position,Bullets[2].transform.rotation);
                    boltInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500.0f, 7000.0f), ForceMode2D.Impulse);
                    Destroy(boltInstance, 1);
                    timeTillNextShot = 0;

                }
            }
        }

    }

    public void WhenToShoot()
    {
        shootNow = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "GenericBullet")
        {
            takeDamage();
            Destroy(collision.gameObject);
        }
    }

}
