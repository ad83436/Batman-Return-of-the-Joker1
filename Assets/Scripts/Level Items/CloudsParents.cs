using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloudsParents : MonoBehaviour
{
    public Vector2 offSet;
    public static  List<CloudsParents> clouds = new List<CloudsParents>();
    public SpriteRenderer cloudsSprites;
    public float xVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void TheCloudMovement();

    public void OnStartUp()
    {
        for(int i =0; i < clouds.Count; ++i)
        {
            cloudsSprites = clouds[i].GetComponent<SpriteRenderer>();
        }
    }

    public void OnDestroy()
    {
        clouds.Remove(this);
    }
}
