using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : HealthandDeath
{
    public bool isDestroyed;
    public Animator crateAnimator;
   // public HealthandDeath creatsHealth;
    public BoxCollider2D createCollider;
    public List<Crates> crates = new List<Crates>();


    // Start is called before the first frame update
    void Start()
    {
        crates.Add(this);
        maxHealth = 5;

        crateAnimator = GetComponent<Animator>();
        createCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public override void Death()
    {
        if (maxHealth <= 0)
        {
            crateAnimator.SetBool("isDestroyed", true);
        }

        if (crateAnimator.GetBool("isDestroyed"))
        {
            createCollider.enabled = false;

        }
    }

    public void DestroyCrate()
    {
        Destroy(gameObject);
    }

    public void takeDamage()
    {
        maxHealth -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GenericBullet" )
        {
            takeDamage();
            Destroy(collision.gameObject);
            Debug.Log("hit crate");
        }
    }

    public void OnDestroy()
    {
        crates.Remove(this);
    }
}
