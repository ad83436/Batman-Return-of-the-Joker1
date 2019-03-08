using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMove : Platforms
{
    public Platforms[] platforms;
    public Platforms thePlatforms;
    public Platforms thePlatforms1;
    public Batman theBats;
    
    // Start is called before the first frame update
    void Start()
    {
        ySpeed = 85;
        xSpeed = 85;
        platforms = new Platforms[3];
        theBats = GameObject.FindWithTag("Batman").GetComponent<Batman>();
        thePlatforms = GameObject.FindWithTag("PlatformFloor").GetComponent<Platforms>();
        thePlatforms1 = GameObject.FindWithTag("PlatformFloor1").GetComponent<Platforms>();
        platforms[0] = GameObject.FindWithTag("PlatformFloor2").GetComponent<Platforms>();
        platforms[1] = GameObject.FindWithTag("PlatformFloor3").GetComponent<Platforms>();
        platforms[2] = GameObject.FindWithTag("PlatformFloor4").GetComponent<Platforms>();
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMovement();
    }

    public void PlatformMovement()
    {
        if (!thePlatforms.hitBound)
        {
            thePlatforms.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, ySpeed);
        }

        else if (thePlatforms.hitBound)
        {
            thePlatforms.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -ySpeed);     
        }

        if (thePlatforms.theBatsOnPlatform && !Input.GetButton("Jump"))
        {
            theBats.GetComponent<Rigidbody2D>().velocity = thePlatforms.GetComponent<Rigidbody2D>().velocity;
        }

        if (!thePlatforms1.hitBound)
        {
            thePlatforms1.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, 0.0f);
        }

        else if (thePlatforms1.hitBound)
        {
            thePlatforms1.GetComponent<Rigidbody2D>().velocity = new Vector2(-xSpeed, 0.0f);
        }

        if (Input.GetButton("Jump"))
        {
            thePlatforms.theBatsOnPlatform = false;
        }

        for (int i = 0; i < 3; ++i)
        {
            if (platforms[i].theBatsOnPlatform && !platforms[i].onFloor )
            {
                platforms[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -51.0f);

                if (!Input.GetButton("Jump"))
                {
                    theBats.GetComponent<Rigidbody2D>().velocity = platforms[i].GetComponent<Rigidbody2D>().velocity;
                }
            }

            if (platforms[i].onFloor)
            {
                platforms[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            }

            if (!platforms[i].theBatsOnPlatform && !platforms[i].hitBound)
            {
                platforms[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 51.0f);
                platforms[i].onFloor = false;
            }

            if (!platforms[i].theBatsOnPlatform)
            {
                platforms[i].onFloor = false;
            }

            if (platforms[i].theBatsOnPlatform)
            {
               platforms[i].hitBound = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor")
        {
            thePlatforms.hitBound = true;
        }

        else if (collision.gameObject.tag == "PlatformBBound" && gameObject.tag == "PlatformFloor")
        {
            thePlatforms.hitBound = false;
        }

        if (collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor1")
        {
            thePlatforms1.hitBound = true;
        }

        else if (collision.gameObject.tag == "PlatformBBound" && gameObject.tag == "PlatformFloor1")
        {
            thePlatforms1.hitBound = false;
        }

        if (collision.gameObject.tag == "PlatformBBound" && gameObject.tag == "PlatformFloor2")
        {
            platforms[0].onFloor = true;
        }

        if(collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor2" )
        {
            platforms[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            platforms[0].hitBound = true;
        }

        if(collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor2")
        {
            platforms[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            platforms[0].onFloor = false;
        }

        if (collision.gameObject.tag == "PlatformBBound" && gameObject.tag == "PlatformFloor3")
        {
            platforms[1].onFloor = true;
        }

        if (collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor3")
        {
            platforms[1].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            platforms[1].hitBound = true;
        }

        if (collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor3")
        {
            platforms[1].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            platforms[1].onFloor = false;
        }

        if (collision.gameObject.tag == "PlatformBBound" && gameObject.tag == "PlatformFloor4")
        {
            platforms[2].onFloor = true;
        }

        if (collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor4")
        {
            platforms[2].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            platforms[2].hitBound = true;
        }

        if (collision.gameObject.tag == "PlatformTBound" && gameObject.tag == "PlatformFloor4")
        {
            platforms[2].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            platforms[2].onFloor = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor" && !Input.GetButton("Jump"))
        {
            thePlatforms.theBatsOnPlatform = true;
        }

        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor2")
        {
            platforms[0].theBatsOnPlatform = true;
            platforms[0].hitBound = false;
        }

        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor3")
        {
            platforms[1].theBatsOnPlatform = true;
            platforms[1].hitBound = false;
        }

        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor4")
        {
            platforms[2].theBatsOnPlatform = true;
            platforms[2].hitBound = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor" )
        {
            thePlatforms.theBatsOnPlatform = false;
        }

        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor1")
        {
            thePlatforms1.theBatsOnPlatform = false;
        }

        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor2")
        {
            platforms[0].theBatsOnPlatform = false;
        }

        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor3")
        {
            platforms[1].theBatsOnPlatform = false;
        }

        if (collision.gameObject.tag == "Batman" && gameObject.tag == "PlatformFloor4")
        {
            platforms[2].theBatsOnPlatform = false;
        }
    }
}
