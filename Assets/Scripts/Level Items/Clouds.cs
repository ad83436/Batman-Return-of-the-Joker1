using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : CloudsParents
{
    public CloudsParents[] clouds;
    // Start is called before the first frame update
    void Start()
    {
        clouds = new CloudsParents[9];
        clouds[0] = GameObject.FindWithTag("Clouds").GetComponent<CloudsParents>();
        clouds[1] = GameObject.FindWithTag("Clouds1").GetComponent<CloudsParents>();
        clouds[2] = GameObject.FindWithTag("Clouds2").GetComponent<CloudsParents>();
        clouds[3] = GameObject.FindWithTag("Clouds3").GetComponent<CloudsParents>();
        clouds[4] = GameObject.FindWithTag("Clouds4").GetComponent<CloudsParents>();
       // clouds[5] = GameObject.FindWithTag("Clouds5").GetComponent<CloudsParents>();
       // clouds[6] = GameObject.FindWithTag("Clouds6").GetComponent<CloudsParents>();
       // clouds[7] = GameObject.FindWithTag("Clouds7").GetComponent<CloudsParents>();
      //  clouds[8] = GameObject.FindWithTag("Clouds8").GetComponent<CloudsParents>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        TheCloudMovement();
    }

    private void TheCloudMovement()
    {
        for(int i = 0; i < 9; ++i)
        {
            if (clouds[i] != null)
            {

                clouds[i].offSet = new Vector2(clouds[i].xVelocity, 0.0f);
                clouds[i].GetComponent<SpriteRenderer>().material.mainTextureOffset += clouds[i].offSet * Time.fixedDeltaTime;
            }
        }
    }
}
