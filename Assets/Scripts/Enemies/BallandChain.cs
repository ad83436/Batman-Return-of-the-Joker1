using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallandChain : MonoBehaviour
{
    public Batman theBats;
    public float fallSpeed;
    public Vector2 Direction;
    public Rigidbody2D ballAndChainRb;
    public  List<BallandChain> BallandChains = new List<BallandChain>();
    public float Distance;
    public float upSpeed;
    public bool hitGround = false;
    public bool hitGuard = false;
    public int Damage = 1;
    public float stickTimer = 0;

    //Fix This//if ball hits the ground it needs to wait for x amount of time before going back up;
    void Start()
    {
        BallandChains.Add(this);
        for(int i = 0; i < BallandChains.Count; ++i)
        {
            ballAndChainRb = BallandChains[i].GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        WhenToFall();
        Direction = theBats.transform.position - gameObject.transform.position;
        Distance = Mathf.Sqrt(Mathf.Pow(Direction.x, 2));
    }

    public void WhenToFall()
    {
        if (Distance <= 70 && !hitGround)
        {
            ballAndChainRb.velocity = new Vector2(0.0f, -fallSpeed);
        }

        if (Distance >= 70 && hitGround)
        {
            ballAndChainRb.velocity = new Vector2(0.0f, upSpeed);
        }

        else if (hitGround)
        {
            ballAndChainRb.velocity = new Vector2(0.0f, upSpeed);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ChainGuard")
        {
            hitGround = false;
        }
    }

    // needs to freeze for x amount of seconds after hitting the floor  fix it later 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor" /*&& gameObject.tag == "BallnChain"*/)
        {
            hitGround = true;
            NoiseManager.instance.PlaySound("BallHitFloor");
        }

        if (!theBats.animation.GetBool("isDead"))
        {
            if (collision.gameObject.tag == "Batman" && theBats.canHit)
            {
                if (!theBats.IsHitForHealthBar)
                {
                    theBats.animation.SetBool("isHit", true);
                    theBats.maxHealth -= Damage;
                }
            }
        }
    }
}
