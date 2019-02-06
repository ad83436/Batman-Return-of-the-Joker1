using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpEnemy : NPC
{

    public bool isDead = false;
    public NPC[] jumpEnemy;

    
    void Start()
    {
        jumpEnemy = new NPC[2];
        jumpEnemy[0] = GameObject.FindWithTag("JumpMan").GetComponent<NPC>();
        jumpEnemy[1] = GameObject.FindWithTag("JumpMan1").GetComponent<NPC>();

    }
    void FixedUpdate()
    {
        Death();
        Spawn();
        // Debug.Log(" jumpMan distances is " + jumpEnemy[0].Distance);
        // Debug.Log(" jumpMan1 distances is " + jumpEnemy[1].Distance);
    }

    public override void Spawn()
    {
        for (int i = 0; i < 2; i++)
        {
            if (jumpEnemy[i] != null)
            {
                if (jumpEnemy[i].Distance > 120)
                {
                    jumpEnemy[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    jumpEnemy[i].GetComponent<SpriteRenderer>().enabled = false;
                    jumpEnemy[i].GetComponent<BoxCollider2D>().enabled = false;
                }
                else if (jumpEnemy[i].Distance < 120)
                {
                    jumpEnemy[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    jumpEnemy[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                    jumpEnemy[i].GetComponent<SpriteRenderer>().enabled = true;
                    jumpEnemy[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
    }

    public override void Death()
    {
        base.Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Batman")
        {
            //Dark_Knight.maxHealth -= jumpEnemy[i].theDamage;
            Debug.Log("You hit me bro");
        }


    }

}


