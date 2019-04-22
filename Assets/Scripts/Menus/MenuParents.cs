using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParents : MonoBehaviour
{
    public bool hitLetterStop;
    public float flashTimer;
    public float endTimer;
    public static bool renderDone;
 
    public float letterMoveSpeed; 
    // Start is called before the first frame update
    void Start()
    {
       renderDone = false;
        endTimer = 0;
        flashTimer = 0;
        hitLetterStop = false ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
