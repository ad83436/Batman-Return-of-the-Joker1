using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Batman : HealthandDeath
{
    private SpriteRenderer render;
    public Rigidbody2D batman;
    public Animator animation;
    public Platforms platform;
    public GameObject GenericBullet;
    public float walkSpeed;
    public bool Grounded = true;
    public bool jumpedHeld = false;
    public float jumpTime = 0;
    public GameObject[] Wall;
    public KnifeThrower[] knifeThrower;
    public bool shootNow = false;
    public bool shootNow2 = false;
    public float fireRate;
    public float fireRate2;
    public string ThePlatforms;
    float nextFire;
    float nextFire1;
    public bool canJump;
    public bool canHit;
    public HealthandDeath batHealth;
    BoxCollider2D crouchCollider;


    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        GenericBullet.GetComponent<GameObject>();
        knifeThrower = new KnifeThrower[2];
        crouchCollider = GameObject.FindWithTag("CrouchCollider").GetComponent<BoxCollider2D>();
        platform = GameObject.FindWithTag("PlatformFloor1").GetComponent<Platforms>();
        batman = GameObject.FindWithTag("Batman").GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        animation = GameObject.FindWithTag("Batman").GetComponent<Animator>();
        Wall = GameObject.FindGameObjectsWithTag("Wall");
        batHealth = GameObject.FindWithTag("Batman").GetComponent<HealthandDeath>();
        knifeThrower[0] = GameObject.FindWithTag("KnifeEnemy").GetComponent<KnifeThrower>();
        knifeThrower[1] = GameObject.FindWithTag("KnifeEnemy1").GetComponent<KnifeThrower>();
        //jumpEnemy[0] = GameObject.FindWithTag("JumpMan").GetComponent<NPC>();
        //jumpEnemy[1] = GameObject.FindWithTag("JumpMan1").GetComponent<NPC>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        theBatsHitCondition();
        TheBatShot();
        TheBatMovement();
        TheBatJump();
        Death();
        HitKnockBack();
    }

    public void TheBatMovement()
    {
        /*Come back and try to improve the Movement*/
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        float x = axisH * walkSpeed;

        Vector2 xForce = new Vector2(x, batman.velocity.y);
        batman.velocity = xForce;

        animation.SetFloat("Speed", Mathf.Abs(xForce.x));

        if (axisH > 0.0f)
        {
            render.flipX = false;
        }

        else if (axisH < 0.0f)
        {
            render.flipX = true;
        }


        if (axisV > 0 && Grounded)
        {
            animation.SetBool("isLookingUp", true);
            walkSpeed = 0;
            canJump = false;
        }

        else if (axisV < 0 && Grounded)
        {
            crouchCollider.enabled = true;
            animation.SetBool("isCrouching", true);
            batman.GetComponent<BoxCollider2D>().enabled = false;
            walkSpeed = 0;
            canJump = false;

        }

        else if (!Grounded)
        {
            walkSpeed = 110;
        }

        else if (animation.GetBool("isHit") == true)
        {
            walkSpeed = 0;
        }
         
        else
        {
            crouchCollider.enabled = false;
            batman.GetComponent<BoxCollider2D>().enabled = true;
            animation.SetBool("isLookingUp", false);
            animation.SetBool("isCrouching", false);
            walkSpeed = 110;
        } 
    }

    private void TheBatJump()
    {
        float jumpHeight = 200.0f;
        JumpConditions();
        if (Input.GetButton("Jump") && canJump)
        {
            animation.SetBool("isJumping", true);

            if (Grounded && jumpTime < .2)
            {
                batman.velocity = new Vector2(0.0f, jumpHeight);
                Grounded = false;

                Debug.Log("the short jump " + batman.velocity.y);
            }

            else if (!Grounded && jumpedHeld)
            {
                batman.velocity *= 3.5f;
                Grounded = false;
                canJump = false;
                Debug.Log("the High jump" + batman.velocity.y);
            }
        }

        if (!Input.GetButton("Jump"))
        {
            canJump = true;
        }

        if (!Grounded)
        {
            animation.SetBool("isJumping", true);
        }
    }

    private void JumpConditions()
    {
        if (Grounded)
        {
            jumpTime = 0;
        }

        else if (!Grounded)
        {
            jumpTime += Time.deltaTime;

            if (jumpTime > .1)
            {
                jumpedHeld = true;
            }

            if (jumpTime > .12)
            {
                jumpedHeld = false;

            }
        }
    }


    //fix so that everytime the button is pushed down for fire 1 that it fires another projectiole and if it is held another type of speical projectile is sho
    private void TheBatShot()
    {
        GameObject BulletInstance;
        GameObject BulletInstance1;

        if (Input.GetButton("Fire1"))
        {
            if (render.flipX == false && Grounded)
            {
                animation.SetBool("isShooting", true);

                if (shootNow && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate2;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = false;
                    GenericBullet.transform.position = batman.position + new Vector2(25.0f, 0.8f);
                    BulletInstance = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(200.0f, 0.0f);
                    Destroy(BulletInstance, 2);
                }
            }

            else if (render.flipX && Grounded)
            {
                animation.SetBool("isShooting", true);

                if (shootNow && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate2;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = true;
                    GenericBullet.transform.position = batman.position + new Vector2(-25.0f, 0.8f);
                    BulletInstance = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                    Destroy(BulletInstance, 2);
                }
            }

        }

        else
        {
            animation.SetBool("isShooting", false);
            shootNow = false;
        }


        if (Input.GetButton("Fire2")) {
            if (render.flipX == false && Grounded)
            {
                animation.SetBool("isShooting2", true);

                if (shootNow2 && Time.time > nextFire1)
                {
                    nextFire1 = Time.time + fireRate;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = false;
                    GenericBullet.transform.position = batman.position + new Vector2(25.0f, 0.8f);
                    BulletInstance1 = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(200.0f, 0.0f);
                    Destroy(BulletInstance1, 2);
                }
            }

            else if (render.flipX && Grounded)
            {
                animation.SetBool("isShooting2", true);

                if (shootNow2 && Time.time > nextFire1)
                {
                    nextFire1 = Time.time + fireRate;

                    GenericBullet.GetComponent<SpriteRenderer>().flipX = true;
                    GenericBullet.transform.position = batman.position + new Vector2(-25.0f, 0.8f);
                    BulletInstance1 = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                    Destroy(BulletInstance1, 2);
                }
            }
        }

        if (Input.GetButton("Fire2") == false)
        {
            animation.SetBool("isShooting2", false);
            shootNow2 = false;
        }
    }

    public override void Death()
    {
        // fix the pivots on the hit and death animations 
        if (batman.GetComponent<HealthandDeath>().maxHealth <= 0)
        {
            animation.SetBool("isDead", true);
            if (animation.GetBool("isDead") == true)
            {
                animation.SetBool("isHit", false);
                batman.velocity = new Vector2(0.0f, 0.0f);
            }
        }

        else
        {
            animation.SetBool("isDead", false);

        }
    }

    public void DeathReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WhenToShoot()
    {
        shootNow = true;
        shootNow2 = true;
    }

    public void HitOver()
    {
        animation.SetBool("isHit", false);
    }
     

    public void HitKnockBack()
    {
        if (animation.GetBool("isHit") == true && render.flipX == false)
        {
            batman.AddForce(new Vector2(-4500.0f, 0.0f), ForceMode2D.Impulse);
        }

        else if (animation.GetBool("isHit") == true && render.flipX == true)
        {
            batman.AddForce(new Vector2(4000.0f, 0.0f), ForceMode2D.Impulse);
        }

        else
        {
            batman.velocity = new Vector2(batman.velocity.x, batman.velocity.y);
        }
    }

    public void CrouchToStand()
    {
        animation.SetBool("isCrouchDone", true);
        animation.SetBool("isCrouchDone", false);
    }

    //when hit batman can flip  and it changes the direction of the knock back ////FIX THIS SHIT////    
    public void theBatsHitCondition()
    {
        if(animation.GetBool("isHit"))
        {
            batHealth.IsHitForHealthBar = true;
            canHit = false;
        }

        else if(!animation.GetBool("isHit"))
        {
            batHealth.IsHitForHealthBar = false;
            canHit = true;
        }
        
    }

    // fix collider issues with ball and chain and make it push you back when hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (animation.GetBool("isDead") == false)
        {
            if (collision.gameObject.tag == "BallnChain" || collision.gameObject.tag == "BallnChain1" || collision.gameObject.tag == "BallnChain2")
            {
                if (!batHealth.IsHitForHealthBar)
                {
                    animation.SetBool("isHit", true);
                    batHealth.maxHealth -= 1;
                }
            }

            if (collision.gameObject.tag == "KnifeEnemy")
            {
                if (!batHealth.IsHitForHealthBar)
                {
                    animation.SetBool("isHit", true);
                    batHealth.maxHealth -= knifeThrower[0].theDamage;
                }
            }

            if (collision.gameObject.tag == "Knife")
            {
                if (!batHealth.IsHitForHealthBar)
                {
                    animation.SetBool("isHit", true);
                    batHealth.maxHealth -= 1;
                }
            }

            if (collision.gameObject.tag == "KnifeEnemy1")
            {
                if (!batHealth.IsHitForHealthBar)
                {
                    animation.SetBool("isHit", true);
                    batHealth.maxHealth -= knifeThrower[1].theDamage;
                }
            }
            

            if (collision.gameObject.tag == "JBULLETS")
            {
                if (!batHealth.IsHitForHealthBar)
                {
                    animation.SetBool("isHit", true);
                    batHealth.maxHealth -= 1;
                }
            }






        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "BoltAttack")
            {
                animation.SetBool("isHit", true);
                batHealth.maxHealth -= 1;
                Destroy(collision.gameObject);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Stand")
            {
                Grounded = true;
                animation.SetBool("isJumping", false);
                jumpedHeld = false;
            }


            if (collision.gameObject.tag == "PlatformFloor" || collision.gameObject.tag == "PlatformFloor2"
                || collision.gameObject.tag == "PlatformFloor3" || collision.gameObject.tag == "PlatformFloor4")
            {
                Grounded = true;
                animation.SetBool("isJumping", false);
                jumpedHeld = false;
            }

            if (collision.gameObject.tag == "PlatformFloor1" || collision.gameObject.tag == "Crate")
            {
                Grounded = true;
                animation.SetBool("isJumping", false);
                jumpedHeld = false;
            }
        }
    
}
