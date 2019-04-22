using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public HealthandDeath theBatsHealth;
    public GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        powerUp = GetComponent<GameObject>();
        theBatsHealth = GameObject.FindWithTag("Batman").GetComponent<HealthandDeath>();      
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Batman")
        {
            NoiseManager.instance.PlaySound("PowerUpCollected");
            theBatsHealth.theDamage += 1;
            Destroy(gameObject);
        }
    }


}
