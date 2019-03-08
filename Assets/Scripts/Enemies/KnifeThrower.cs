using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : NPC
{
    public NPC[] knifeThrower;
   
    bool animationState1 = false;
    bool animationState2 = false;
    bool animationState3 = false;
    public bool gotHit = false;
    // Start is called before the first frame update
    void Start()
    {
        knifeThrower = new NPC[2];
        knifeThrower[0] = GameObject.FindWithTag("KnifeEnemy").GetComponent<NPC>();
        knifeThrower[1] = GameObject.FindWithTag("KnifeEnemy1").GetComponent<NPC>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        NpcShot();
    }

    public override void Movement()
    {

    }

    private void OnBecameVisible()
    {
        NpcShot();
    }

    public override void NpcShot()
    {
        GameObject knifeInstance;
        for (int i = 0; i < 2; ++i)
        {
            if (knifeThrower[i] != null)
            {
                if (knifeThrower[i].Distance < 100 && knifeThrower[i].angle < 90)
                {
                    knifeThrower[i].timeTillNextShot += Time.fixedDeltaTime;
                    
                    if (knifeThrower[i].timeTillNextShot >= 4)
                    {
                        knifeThrower[i].GetComponent<Animator>().SetBool("inRange", true);


                        if (Time.time > knifeThrower[i].nextFire)
                        {
                            if (knifeThrower[i].canAttack)
                            {
                                Bullets[1].GetComponent<SpriteRenderer>().flipX = true;
                                knifeThrower[i].nextFire = Time.time + knifeThrower[i].fireRate;
                                knifeThrower[i].Bullets[1].transform.position = knifeThrower[i].GetComponent<Rigidbody2D>().position + new Vector2(-25.0f, 0.0f);
                                knifeInstance = Instantiate(knifeThrower[i].Bullets[1], knifeThrower[i].Bullets[1].transform.position, knifeThrower[i].Bullets[1].transform.rotation);                             
                                knifeInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                            }
                        }
                    }

                    if (knifeThrower[i].Distance < 100 && knifeThrower[i].timeTillNextShot >= 4.5)
                    {
                        knifeThrower[i].canAttack = false;
                        knifeThrower[i].timeTillNextShot = 0;
                        knifeThrower[i].GetComponent<Animator>().SetBool("inRange", false);
                    }
                }

                else if (knifeThrower[i].Distance < 100 && knifeThrower[i].angle > 90)
                {
                    knifeThrower[i].timeTillNextShot += Time.fixedDeltaTime;

                    if (knifeThrower[i].timeTillNextShot >= 4)
                    {
                        knifeThrower[i].GetComponent<Animator>().SetBool("inRange", true);
                       

                        if (Time.time > knifeThrower[i].nextFire)
                        {
                            if (knifeThrower[i].canAttack)
                            {
                                Bullets[1].GetComponent<SpriteRenderer>().flipX = false;
                                knifeThrower[i].nextFire = Time.time + knifeThrower[i].fireRate;
                                knifeThrower[i].Bullets[1].transform.position = knifeThrower[i].GetComponent<Rigidbody2D>().position + new Vector2(25.0f, 0.0f);
                                knifeInstance = Instantiate(knifeThrower[i].Bullets[1], knifeThrower[i].Bullets[1].transform.position, knifeThrower[i].Bullets[1].transform.rotation);
                                knifeInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(200.0f, 0.0f);
                            }
                        }
                    }

                    if (knifeThrower[i].Distance < 100 && knifeThrower[i].timeTillNextShot >= 4.5)
                    {
                        knifeThrower[i].canAttack = false;
                        knifeThrower[i].timeTillNextShot = 0;
                        knifeThrower[i].GetComponent<Animator>().SetBool("inRange", false);
                    }


                    else if (knifeThrower[i].Distance > 100)
                    {
                        
                            knifeThrower[i].canAttack = false;
                            knifeThrower[i].GetComponent<Animator>().SetBool("inRange", false);
                    }
                }
            }
        }

    }

    public void WhenToShoot()
    {
        knifeThrower[0].canAttack = true;      
        knifeThrower[1].canAttack = true;      
                
           
    }
    public void AnimationState1()
    {
        animationState1 = true;
    }

    public void AnimationState2()
    {
        animationState2 = true;
    }

    public void AnimationState3()
    {
        animationState3 = true;
    }

    public override void FacePlayer()
    {
        base.FacePlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GenericBullet")
        {
            gotHit = true; 
            knifeThrower[0].maxHealth -= 1;
            Destroy(collision.gameObject);
            Death();
        }

        if (collision.gameObject.tag == "GenericBullet")
        {
            gotHit = true;
            knifeThrower[1].maxHealth -= 1;
            Destroy(collision.gameObject);
            Death();
        }
    }
}
