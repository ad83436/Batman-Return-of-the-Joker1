using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuParents
{
    public MenuParents[] mainMenuLetters;
    public SpriteRenderer tradeMark;
    public SpriteRenderer rOfTheJ;
    public SpriteRenderer sunSoft;
    public SpriteRenderer newGameButton;
    public SpriteRenderer Settings;
    public SpriteRenderer Dot;
 
    // Start is called before the first frame update
    void Start()
    {
        mainMenuLetters = new MenuParents[6];
        mainMenuLetters[0] = GameObject.FindWithTag("B").GetComponent<MenuParents>();
        mainMenuLetters[1] = GameObject.FindWithTag("A").GetComponent<MenuParents>();
        mainMenuLetters[2] = GameObject.FindWithTag("T").GetComponent<MenuParents>();
        mainMenuLetters[3] = GameObject.FindWithTag("M").GetComponent<MenuParents>();
        mainMenuLetters[4] = GameObject.FindWithTag("A1").GetComponent<MenuParents>();
        mainMenuLetters[5] = GameObject.FindWithTag("N").GetComponent<MenuParents>();
        tradeMark = GameObject.FindWithTag("TM").GetComponent<SpriteRenderer>();
        rOfTheJ = GameObject.FindWithTag("ROTJ").GetComponent<SpriteRenderer>();
        sunSoft = GameObject.FindWithTag("SUNSOFT").GetComponent<SpriteRenderer>();
        newGameButton = GameObject.FindWithTag("NGB").GetComponent<SpriteRenderer>();
        Dot = GameObject.FindWithTag("NGDot").GetComponent<SpriteRenderer>();
        NoiseManager.instance.PlaySound("MainMenuMusic");

    }

    // Update is called once per frame
    void Update()
    {
        MoveLetters();
        RenderSprites();  
    }

    void RenderSprites()
    {
        if (endTimer <= 4)
        {
            if (mainMenuLetters[5].hitLetterStop)
            {
                endTimer += Time.deltaTime;
                tradeMark.enabled = true;
                flashTimer += Time.deltaTime;

                if (flashTimer >= 0.2 && flashTimer <= 0.4)
                {
                    rOfTheJ.enabled = true;
                }

                else if (flashTimer >= 0.7)
                {
                    rOfTheJ.enabled = false;
                    flashTimer = 0;
                }
            }
        }

        else
        {
            flashTimer = 0.3f;
            sunSoft.enabled = true;
            newGameButton.enabled = true;
            renderDone = true;
            Settings.enabled = true;

            if (HoverRender.isHovering)
            {
                Dot.enabled = true;
            }
            else
            {
                Dot.enabled = false;
            }

        }
    }

     void MoveLetters()
    {
        if (!mainMenuLetters[0].hitLetterStop)
        {
            mainMenuLetters[0].GetComponent<Rigidbody2D>().velocity = new Vector2(-mainMenuLetters[0].letterMoveSpeed, 0.0f);
            
        }

        else
        {
            mainMenuLetters[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }

        if (!mainMenuLetters[1].hitLetterStop && mainMenuLetters[0].hitLetterStop)
        {
            mainMenuLetters[1].GetComponent<Rigidbody2D>().velocity = new Vector2(-mainMenuLetters[1].letterMoveSpeed, 0.0f);
        }

        if(mainMenuLetters[1].hitLetterStop)
        {
            mainMenuLetters[1].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }

        if (!mainMenuLetters[2].hitLetterStop && mainMenuLetters[1].hitLetterStop)
        {
            mainMenuLetters[2].GetComponent<Rigidbody2D>().velocity = new Vector2(-mainMenuLetters[2].letterMoveSpeed, 0.0f);
        }

        if(mainMenuLetters[2].hitLetterStop)
        {
            mainMenuLetters[2].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }

        if (!mainMenuLetters[3].hitLetterStop && mainMenuLetters[2].hitLetterStop)
        {
            mainMenuLetters[3].GetComponent<Rigidbody2D>().velocity = new Vector2(-mainMenuLetters[3].letterMoveSpeed, 0.0f);
        }

        if(mainMenuLetters[3].hitLetterStop)
        {
            mainMenuLetters[3].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }

        if (!mainMenuLetters[4].hitLetterStop && mainMenuLetters[3].hitLetterStop)
        {
            mainMenuLetters[4].GetComponent<Rigidbody2D>().velocity = new Vector2(-mainMenuLetters[4].letterMoveSpeed, 0.0f);
        }

        if(mainMenuLetters[4].hitLetterStop)
        {
            mainMenuLetters[4].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }

        if (!mainMenuLetters[5].hitLetterStop && mainMenuLetters[4].hitLetterStop)
        {
            mainMenuLetters[5].GetComponent<Rigidbody2D>().velocity = new Vector2(-mainMenuLetters[5].letterMoveSpeed, 0.0f);
        }

        if(mainMenuLetters[5].hitLetterStop)
        {
            mainMenuLetters[5].GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LetterHolder" && gameObject.tag == "B")
        {
            mainMenuLetters[0].hitLetterStop = true;
           
        }

        if (collision.gameObject.tag == "LetterHolder1" && gameObject.tag == "A")
        {
            mainMenuLetters[1].hitLetterStop = true;
            
        }

        if (collision.gameObject.tag == "LetterHolder2" && gameObject.tag == "T")
        {
            mainMenuLetters[2].hitLetterStop = true;
            
        }

        if (collision.gameObject.tag == "LetterHolder3" && gameObject.tag == "M")
        {
            mainMenuLetters[3].hitLetterStop = true;
        }

        if (collision.gameObject.tag == "LetterHolder4" && gameObject.tag == "A1")
        {
            mainMenuLetters[4].hitLetterStop = true;
        }

        if (collision.gameObject.tag == "LetterHolder5" && gameObject.tag == "N")
        {
            mainMenuLetters[5].hitLetterStop = true;
        }
    }
}
