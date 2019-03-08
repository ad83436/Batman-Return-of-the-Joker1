using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyles : NPC
{
    public NPC gargoyle;
   
    public bool shootNow = false;
  
    public float minBound;
    public float maxBound; 

    // Start is called before the first frame update
    void Start()
    {
        gargoyle = GameObject.FindWithTag("gargoyle").GetComponent<NPC>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        NpcShot();
        FacePlayer();
        Movement();
    }

    public override void NpcShot()
    {
        GameObject boltInstance;
        if(gargoyle.Distance > 50 && gargoyle.Distance < 100 && Mathf.Abs(gargoyle.angle) < 90.0f )
        {
            gargoyle.timeTillNextShot += Time.fixedDeltaTime;

            if(gargoyle.timeTillNextShot > 1.5)
            {
                if (Time.time > gargoyle.nextFire) {
                    gargoyle.nextFire = Time.time + gargoyle.fireRate;
                    gargoyle.Bullets[2].transform.position = gargoyle.GetComponent<Rigidbody2D>().position + new Vector2(-11.0f, 25.0f);
                    boltInstance = Instantiate(gargoyle.Bullets[2], gargoyle.Bullets[2].transform.position,gargoyle.Bullets[2].transform.rotation);
                    boltInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3200.0f, 7000.0f), ForceMode2D.Impulse);
                    Destroy(boltInstance, 5);
                    
                }
            }
        }

        else if(gargoyle.Distance < 50 && Mathf.Abs(gargoyle.angle) < 90.0f)
        {
            gargoyle.timeTillNextShot += Time.fixedDeltaTime;

            if (gargoyle.timeTillNextShot > 1.5)
            {
                if (Time.time > gargoyle.nextFire)
                {
                    gargoyle.nextFire = Time.time + gargoyle.fireRate;
                    gargoyle.Bullets[2].transform.position = gargoyle.GetComponent<Rigidbody2D>().position + new Vector2(-11.0f, 25.0f);
                    boltInstance = Instantiate(gargoyle.Bullets[2], gargoyle.Bullets[2].transform.position, gargoyle.Bullets[2].transform.rotation);
                    boltInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500.0f, 7000.0f), ForceMode2D.Impulse);
                    Destroy(boltInstance, 5);

                }
            }
        }

        if (gargoyle.Distance > 50 && gargoyle.Distance < 100 && thisTurned == false)
        {
            gargoyle.timeTillNextShot += Time.fixedDeltaTime;

            if (gargoyle.timeTillNextShot > 1.5)
            {
                if (Time.time > gargoyle.nextFire)
                {
                    gargoyle.nextFire = Time.time + gargoyle.fireRate;
                    gargoyle.Bullets[2].transform.position = gargoyle.GetComponent<Rigidbody2D>().position + new Vector2(11.0f, 25.0f);
                    boltInstance = Instantiate(gargoyle.Bullets[2], gargoyle.Bullets[2].transform.position, gargoyle.Bullets[2].transform.rotation);
                    boltInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(3200.0f, 7000.0f), ForceMode2D.Impulse);
                    Destroy(boltInstance, 5);

                }
            }
        }

        else if (gargoyle.Distance < 50 && thisTurned)
        {
            gargoyle.timeTillNextShot += Time.fixedDeltaTime;

            if (gargoyle.timeTillNextShot > 1.5)
            {
                if (Time.time > gargoyle.nextFire)
                {
                    gargoyle.nextFire = Time.time + gargoyle.fireRate;
                    gargoyle.Bullets[2].transform.position = gargoyle.GetComponent<Rigidbody2D>().position + new Vector2(11.0f, 25.0f);
                    boltInstance = Instantiate(gargoyle.Bullets[2], gargoyle.Bullets[2].transform.position, gargoyle.Bullets[2].transform.rotation);
                    boltInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500.0f, 7000.0f), ForceMode2D.Impulse);
                    Destroy(boltInstance, 5);

                }
            }
        }
    }


    public override void FacePlayer()
    {
        if (Mathf.Abs(gargoyle.angle) < 90.0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false ;
            thisTurned = false;
        }
        if (Mathf.Abs(gargoyle.angle) > 90.0f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            thisTurned = true;
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
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
