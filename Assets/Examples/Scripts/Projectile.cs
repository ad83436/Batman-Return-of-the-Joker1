using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 StartingVelocity;
    public Vector2 StartingPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = StartingPosition;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = StartingVelocity;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
