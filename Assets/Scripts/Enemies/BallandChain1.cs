using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallandChain1 : MonoBehaviour
{
    public Rigidbody2D Chain2;
    public GameObject theBats;
    public float Distance2;
    public float upSpeed;
    public float fallSpeed;
    public bool hitGround2 = false;

    // Start is called before the first frame update
    void Start()
    {
        theBats = GameObject.FindWithTag("Batman");
        Chain2 = GameObject.FindWithTag("BallnChain2").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        WhenToFall();
        GetDistance();
    }

    public void WhenToFall()
    {
        if (Distance2 <= 70 && !hitGround2)
        {
            Chain2.velocity = new Vector2(0.0f, -fallSpeed);
        }

        if (Distance2 >= 70)
        {
            Chain2.velocity = new Vector2(0.0f, upSpeed);
        }

        else if (hitGround2)
        {
            Chain2.velocity = new Vector2(0.0f, upSpeed);
        }
    }

    public void GetDistance()
    {
        Vector2 Direction2 = theBats.transform.position - Chain2.transform.position;
        Distance2 = Mathf.Sqrt(Mathf.Pow(Direction2.x, 2));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ChainGuard")
        {
            hitGround2 = false;
            Chain2.velocity = new Vector2(0.0f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            hitGround2 = true;
            Chain2.velocity = new Vector2(0.0f, upSpeed);
        }
    }
}
