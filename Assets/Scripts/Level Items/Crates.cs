using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : CrateParents
{
    public CrateParents[] crates;
    
    // Start is called before the first frame update
    void Start()
    {
        crates = new CrateParents[9];
        crates[0] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[1] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[2] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[3] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[4] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[5] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[6] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[7] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[8] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
       // crates[9] = GameObject.FindWithTag("Crate").GetComponent<CrateParents>();
 
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public override void Death()
    {
        if(crates[0].maxHealth <= 0)
        {
            crates[0].GetComponent<Animator>().SetBool("isDestroyed", true);
        }

        if(crates[0].GetComponent<Animator>().GetBool("isDestroyed") == true)
        {
            crates[0].GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void DestroyCrate()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "GenericBullet" && gameObject.tag == "Crate") 
        {
            takeDamage();
            Destroy(collision.gameObject);
           
        }
    }
}
