using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallandChain : MonoBehaviour
{
    public Rigidbody2D Chain;
    public GameObject theBats;
    public float fallSpeed;
    public float Distance;
    public float upSpeed;
    public bool hitGround = false;

   
     
    // Start is called before the first frame update
    void Start()
    {
        theBats = GameObject.FindWithTag("Batman");
        Chain = GameObject.FindWithTag("BallnChain").GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    private void Update()
    {
        WhenToFall();
        GetDistance();
    }

    public void WhenToFall()
    {
        if (Distance <= 70 && !hitGround)
        {
            Chain.velocity = new Vector2(0.0f, -fallSpeed);
        }
  
         if (Distance >= 70)
         {
            Chain.velocity = new Vector2(0.0f, upSpeed);
         }

         else if (hitGround)
         {
            Chain.velocity = new Vector2(0.0f, upSpeed);
         }
    }
    
    private void GetDistance()
    {
        Vector2 Direction = theBats.transform.position - Chain.transform.position;
        Distance = Mathf.Sqrt(Mathf.Pow(Direction.x, 2));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ChainGuard")
        {
            hitGround = false;
            Chain.velocity = new Vector2(0.0f, 0.0f);
        }
    }

    // needs to freeze for x amount of seconds after hitting the floor  fix it later 
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            hitGround = true;
            Chain.velocity = new Vector2(0.0f, upSpeed);
        }
       
    }
}
