using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallandChain2 : MonoBehaviour
{
    public float Distance1;
    public float fallSpeed;
    public Rigidbody2D Chain1;
    public GameObject theBats;
    public float upSpeed;
    public bool hitGround1 = false;
    // Start is called before the first frame update
    void Start()
    {
        theBats = GameObject.FindWithTag("Batman");
        Chain1 = GameObject.FindWithTag("BallnChain1").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        WhenToFall();
        GetDistance();
    }

    public void WhenToFall()
    {

        if (Distance1 <= 70 && !hitGround1)
        {
            Chain1.velocity = new Vector2(0.0f, -fallSpeed);
        }

        if (Distance1 >= 70)
        {
            Chain1.velocity = new Vector2(0.0f, upSpeed);
        }
        else if (hitGround1)
        {
            Chain1.velocity = new Vector2(0.0f, upSpeed);
        }
    }
    public void GetDistance()
    {
        Vector2 Direction1 = theBats.transform.position - Chain1.transform.position;
        Distance1 = Mathf.Sqrt(Mathf.Pow(Direction1.x, 2));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ChainGuard")
        {
            hitGround1 = false;
            Chain1.velocity = new Vector2(0.0f, 0.0f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            hitGround1 = true;
            Chain1.velocity = new Vector2(0.0f, upSpeed);
        }
    }
}
