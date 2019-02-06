using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Batman:HealthandDeath
{
    private SpriteRenderer render;
    public Rigidbody2D batman;
    public HealthandDeath DarkKnight;
    public Animator animation;
    public float walkSpeed;
    public bool Grounded = true;
    public bool jumpedHeld = false;
    public float jumpTime = 0;
    public GameObject[] Wall;
    public NPC[] jumpEnemy;
    
   
  


    // Start is called before the first frame update
    void Start()
    {
        jumpEnemy = new NPC[2];
        batman = GameObject.FindWithTag("Batman").GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        animation = GameObject.FindWithTag("Batman").GetComponent<Animator>();
        Wall = GameObject.FindGameObjectsWithTag("Wall");
        
        jumpEnemy[0] = GameObject.FindWithTag("JumpMan").GetComponent<NPC>();
        jumpEnemy[1] = GameObject.FindWithTag("JumpMan1").GetComponent<NPC>();

        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        theBatMovement();
        theBatJump();
        Death();
        
    }

    public void theBatMovement()
    {
     
        /*Come back and try to improve the Movement*/
           float axisH = Input.GetAxis("Horizontal");
        float lookingUp = Input.GetAxis("Vertical");
            float x = axisH * walkSpeed;
       
         Vector2 xForce = new Vector2(x, batman.velocity.y);
        batman.velocity = xForce;
       

        animation.SetFloat("Speed", Mathf.Abs(xForce.x));

            if (xForce.x > 0.0f)
            {
                render.flipX = false;
            }

            else if (xForce.x < 0.0f)
            {
                render.flipX = true;
            }  

            if (lookingUp > 0) {
               animation.SetBool("isLookingUp", true);
               walkSpeed = 0;
            }else
            {
              animation.SetBool("isLookingUp", false);
              walkSpeed = 110;
            }
    }

    private void theBatJump()
    {
        /* TO DO::Jump feesls to much like a double jump  opposed to one smooth higher jump. Wall colliders need to be -
          fixed batman can jump off the walls because collider is colliding with the Floor collider. Improve animations like pre jump and laning animation
         also need to fix the fact that batman can jump once hitting the ground need to add a cool down system in between jumps*/
        jumpConditions();
        if (Input.GetButton("Jump"))
        {
            animation.SetBool("isJumping", true);
            if (batman.velocity.y > 0.00001f)
            {
                animation.SetBool("Landed", true);
            }

            if (Grounded && jumpTime < .2)
            {
                batman.velocity = new Vector2(0.0f, 135.0f);
                Grounded = false;
                Debug.Log("the short jump " + batman.velocity.y);
            }

            else if (!Grounded && jumpedHeld)
            {
                batman.velocity *= 3.0f;
                Grounded = false;
                Debug.Log("the High jump" + batman.velocity.y);
            }
        }
    }
    private void jumpConditions()
    {
        
        if (Grounded)
        {
            jumpTime = 0;

        }
        else if (!Grounded)
        {
            jumpTime += Time.deltaTime;
            if (jumpTime > .2)
            {
                jumpedHeld = true;
            }
            if (jumpTime > .22)
            {
                jumpedHeld = false;
            }  
        }
    }
  
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("YOu are Grounded");
            Grounded = true;
            animation.SetBool("isJumping", false);
            jumpedHeld = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "JumpMan")
        {
            jumpEnemy[0].maxHealth -= batman.GetComponent<HealthandDeath>().theDamage;
        }
    }
    public override void Death()
    {
        if(batman.GetComponent<HealthandDeath>().maxHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
    
}
