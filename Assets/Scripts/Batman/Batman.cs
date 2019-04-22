using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Batman : HealthandDeath
{
    private SpriteRenderer render;
    public Rigidbody2D batman;
    public Animator animation;
    public Platforms platform;
    public GameObject GenericBullet;
    public float walkSpeed;
    public bool Grounded;
    public bool jumpedHeld = false;
    public float jumpTime = 0;
    public bool shootNow = false;
    public bool shootNow2 = false;
    public float fireRate;
    public float fireRate2;
    public string ThePlatforms;
    public float timeTillNextJumpAllowed;
    float nextFire;
    float nextFire1;
    public bool canJump;
    public bool canHit;
    public HealthandDeath batHealth;
    BoxCollider2D crouchCollider;
    public bool canFlip;
    public static bool gameOver = false;
    public static bool isWalking;
    public bool introDone;
    public static bool isDead = false;



    // Start is called before the first frame update
    public void Start()
    {
        NoiseManager.instance.PlaySound("Intro");
        NoiseManager.instance.PlaySound("GoFuckYourSelf");
        canJump = true;
        GenericBullet.GetComponent<GameObject>();
        crouchCollider = GameObject.FindWithTag("CrouchCollider").GetComponent<BoxCollider2D>();
        batman = GameObject.FindWithTag("Batman").GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        animation = GameObject.FindWithTag("Batman").GetComponent<Animator>();
        batHealth = GameObject.FindWithTag("Batman").GetComponent<HealthandDeath>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        theBatsHitCondition();
        TheBatShot();
        TheBatMovement();
        TheBatJump();
        Death();
        HitKnockBack();
        GameOver();
        IntroDone();
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

        if (axisH > 0.0f && canFlip)
        {
            render.flipX = false;
        }

        else if (axisH < 0.0f && canFlip)
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

        else if (animation.GetBool("isHit"))
        {
            walkSpeed = 0;
            canFlip = false;
            canJump = false;
        }

        else
        {
            canFlip = true;
            crouchCollider.enabled = false;
            batman.GetComponent<BoxCollider2D>().enabled = true;
            animation.SetBool("isLookingUp", false);
            animation.SetBool("isCrouching", false);
            walkSpeed = 110;
        }

        if (Mathf.Abs(batman.velocity.x) > 0.1)
        {
            isWalking = true;
        }

        else
        {
            isWalking = false;
        }
    }

    //NEEDS FIX// Player can jump right when they hit the floor needs a cool down so that when the
    //player lands  they need to wait a second r 2 before they can jump again
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
                NoiseManager.instance.PlaySound("BatJumpSound");
            }

            else if (!Grounded && jumpedHeld)
            {
                batman.velocity *= 3.5f;
                Grounded = false;
                canJump = false;
                Debug.Log("the High jump" + batman.velocity.y);
            }
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

        if (Input.GetButton("Fire1") && !animation.GetBool("isCrouching"))
        {
            canJump = false;
            if (render.flipX == false && Grounded)
            {

                animation.SetBool("isShooting", true);

                if (shootNow && Time.time > nextFire)
                {
                    NoiseManager.instance.PlaySound("BatShot");
                    nextFire = Time.time + fireRate2;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = false;
                    GenericBullet.transform.position = batman.position + new Vector2(25.0f, 1.0f);
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
                    NoiseManager.instance.PlaySound("BatShot");
                    nextFire = Time.time + fireRate2;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = true;
                    GenericBullet.transform.position = batman.position + new Vector2(-25.0f, 1.0f);
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

        if (Input.GetButton("Fire2") && !animation.GetBool("isCrouching"))
        {
            canJump = false;
           
            if (render.flipX == false && Grounded)
            {
                animation.SetBool("isShooting2", true);

                if (shootNow2 && Time.time > nextFire1)
                {
                    NoiseManager.instance.PlaySound("BatShot");
                    nextFire1 = Time.time + fireRate;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = false;
                    GenericBullet.transform.position = batman.position + new Vector2(25.0f, 1.0f);
                    BulletInstance = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(200.0f, 0.0f);
                    Destroy(BulletInstance, 2);
                }
            }

            else if (render.flipX && Grounded)
            {
                animation.SetBool("isShooting2", true);

                if (shootNow2 && Time.time > nextFire1)
                {
                    NoiseManager.instance.PlaySound("BatShot");
                    nextFire1 = Time.time + fireRate;

                    GenericBullet.GetComponent<SpriteRenderer>().flipX = true;
                    GenericBullet.transform.position = batman.position + new Vector2(-25.0f, 1.0f);
                    BulletInstance = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                    Destroy(BulletInstance, 2);
                }
            }
        }

        if (!Input.GetButton("Fire2"))
        {

            animation.SetBool("isShooting2", false);
            shootNow2 = false;
        }



        #region CrouchShooting

        if (Input.GetButton("Fire1") & animation.GetBool("isCrouching"))
        {
            animation.SetBool("isCrouchShooting", true);

            shootNow = true;
            if (shootNow && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate2;

                if (!render.flipX && Grounded)
                {
                    NoiseManager.instance.PlaySound("BatShot");
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = false;
                    GenericBullet.transform.position = batman.position + new Vector2(25.0f, -18.0f);
                    BulletInstance1 = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(200.0f, 0.0f);
                    Destroy(BulletInstance1, 2);
                }

                else if (render.flipX && Grounded)
                {
                    NoiseManager.instance.PlaySound("BatShot");
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = true;
                    GenericBullet.transform.position = batman.position + new Vector2(-25.0f, -18.0f);
                    BulletInstance1 = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                    Destroy(BulletInstance1, 2);
                }
            }
        }

       

        else if (Input.GetButton("Fire2") && animation.GetBool("isCrouching"))
        {
            canJump = false;
            animation.SetBool("isCrouchShooting", true);
            shootNow2 = true;

            if (shootNow2 && Time.time > nextFire1)
            {
                if (!render.flipX && Grounded)
                {
                    NoiseManager.instance.PlaySound("BatShot");
                    nextFire1 = Time.time + fireRate;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = false;
                    GenericBullet.transform.position = batman.position + new Vector2(25.0f, -18.0f);
                    BulletInstance1 = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(200.0f, 0.0f);
                    Destroy(BulletInstance1, 2);
                }

                else if (render.flipX && Grounded)
                {
                    NoiseManager.instance.PlaySound("BatShot");
                    nextFire1 = Time.time + fireRate;
                    GenericBullet.GetComponent<SpriteRenderer>().flipX = true;
                    GenericBullet.transform.position = batman.position + new Vector2(-25.0f, -18.0f);
                    BulletInstance1 = Instantiate(GenericBullet, GenericBullet.transform.position, GenericBullet.transform.rotation);
                    BulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(-200.0f, 0.0f);
                    Destroy(BulletInstance1, 2);

                }
            }
        }
        else
        {
            animation.SetBool("isCrouchShooting", false);
        }


        #endregion

       
    }

    public override void Death()
    {
        // fix the pivots on the hit and death animations 
        if (maxHealth <= 0)
        {
            animation.SetBool("isDead", true);
            isDead = true;

            if (animation.GetBool("isDead"))
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
        theBatLives -= 1;
        isDead = false;
    }

    public void GameOver()
    {
        if (theBatLives <= 0)
        {
            SceneManager.LoadScene("CountDown");

        }
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
        canJump = true;
    }

    //when hit batman can flip  and it changes the direction of the knock back ////FIX THIS SHIT////    
    public void theBatsHitCondition()
    {
        if (animation.GetBool("isHit"))
        {
            batHealth.IsHitForHealthBar = true;
            canHit = false;
            canJump = false;
        }

        else if (!animation.GetBool("isHit"))
        {
            batHealth.IsHitForHealthBar = false;
            canHit = true;
        }
    }

    public void IntroDone()
    {
        if (!animation.GetBool("introDone"))
        {
            batman.velocity = new Vector2(60, -100);
        }

        if (Grounded)
        {
            if (introDone)
            {
                animation.SetBool("introDone", true);
            }
        }
    }

    public void endIntroAnimation()
    {
        introDone = true;
        NoiseManager.instance.PlaySound("MainLoop");
    }

    public void playHitSound()
    {
        NoiseManager.instance.PlaySound("BatmanHit");
    }

    public void PlayDeathNoise()
    {
        NoiseManager.instance.PlaySound("BatmanDeath");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!batHealth.IsHitForHealthBar)
        {
            if (collision.gameObject.tag == "Knife")
            {
                animation.SetBool("isHit", true);
                batHealth.maxHealth -= 1;
                Debug.Log("You hit me bro");
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
            canJump = true;
        }

        if (collision.gameObject.tag == "PlatformFloor" || collision.gameObject.tag == "PlatformFloor2"
            || collision.gameObject.tag == "PlatformFloor3" || collision.gameObject.tag == "PlatformFloor4")
        {
            Grounded = true;
            animation.SetBool("isJumping", false);
            jumpedHeld = false;
            canJump = true;
        }

        if (collision.gameObject.tag == "PlatformFloor1")
        {
            Grounded = true;
            animation.SetBool("isJumping", false);
            jumpedHeld = false;
            canJump = true;
        }

        if (collision.gameObject.tag == "CrateHitBox" || collision.gameObject.tag == "CrateHitBox1" || collision.gameObject.tag == "CrateHitBox2" || collision.gameObject.tag == "CrateHitBox3"
            || collision.gameObject.tag == "CrateHitBox4" || collision.gameObject.tag == "CrateHitBox5" || collision.gameObject.tag == "CrateHitBox6" || collision.gameObject.tag == "CrateHitBox7")
        {
            Grounded = true;
            animation.SetBool("isJumping", false);
            jumpedHeld = false;
            canJump = true;
        }
    }
}