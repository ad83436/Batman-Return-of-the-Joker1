using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : CloudsParents
{
   
    // Start is called before the first frame update
    void Start()
    {
        CloudsParents.clouds.Add(this);
        OnStartUp();
    }

    // Update is called once per frame
    private void Update()
    {
        TheCloudMovement();
    }
    public override void TheCloudMovement()
    {
        offSet = new Vector2(xVelocity, 0.0f);
        cloudsSprites.material.mainTextureOffset += offSet * Time.deltaTime;
    }
}
