using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class PhysicsExample : MonoBehaviour
    {
        private Rigidbody2D rbody;

        // Start is called before the first frame update
        void Start()
        {
            rbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        //-----------------COLLISION METHODS----------------//
        //These methods are called by Unity if this script is on a gameobject with a RigidBody2D component AND at least 1 Collider component
        //If you're having problems with colliders not colliding, check https://docs.unity3d.com/Manual/CollidersOverview.html.
        //The 'Collision Action Matrix' will show which combination of static/rigidbody/kinematic/trigger colliders will work together


        //Called when another collider first makes contact. If a collider is 'standing' on this collider, will be called once
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //good place to play a sound, for example!
            //or to take damage if contact with spikes
            /*
            Character ch = collision.collider.GetComponent<Character>();
            if (ch != null)
            {
                ch.health -= 5;
            }
            */
        }

        //Called when another collider stops making contact. If a collider was 'standing' on this collider, will be called once as soon as it loses contact
        private void OnCollisionExit2D(Collision2D collision)
        {
            
        }

        //Called every frame that a collider is making contact. If a collider is 'standing' on this collider, will be called repeatedly, once per frame.
        private void OnCollisionStay2D(Collision2D collision)
        {
            //'collision' is a parameter of type Collision2D for this method
            //Collision2D has several variables and methods that provide information about the collision that just happened between two Colliders.

            //This lets you get the 'incoming' collider, from the gameobject that hit us, not the gameobject that has this script on it.
            Collider2D colA = collision.collider;

            //This lets you get the collider on this gameobject. The gameobject this script is on. This is very useful if there is more than one collider 
            //  on this gameobject.
            Collider2D colB = collision.otherCollider;

            //We can also get the rigidbodys
            Rigidbody2D rbA = collision.rigidbody;
            Rigidbody2D rbB = collision.otherRigidbody;

            //Using either the collider or the rigidbody, we can get other components too!

            //Here I'm getting the collider of the object that hit me, getting it's SpriteRenderer component and flipping its sprite
            SpriteRenderer sr = colA.GetComponent<SpriteRenderer>();
            sr.flipX = true;

            //Remember, GetComponent only gives you the reference if the component exists! If something hit me without a SpriteRenderer component
            //  I would have gotten null. We should use an if to guard against that.
            SpriteRenderer sr2 = colA.GetComponent<SpriteRenderer>();
            if (sr2 != null)
            {
                sr2.flipX = true;
            }

            //You can also use GetComponent to figure out what kind of object hit us.
            //if you have a script named Character, you can do this.
            /*
            Character character = colA.GetComponent<Character>();
            if (character != null)
            {
                //If character is not null, we know we we're just hit by the character because only our character gameobject has the Character script component
            }
            */

            //----ADVANCED---//

            //'collision' also has a list of places where it's made contact with another collider
            //This is a nice way to figure out which side of a collider has made contact
            //We use a loop to check all contacts
            for (int i = 0; i < collision.contactCount; i++)
            {
                ContactPoint2D cp = collision.GetContact(i);

                //This tells us the exact x,y coordinate that the collider made contact
                Vector2 point = cp.point;

                //The normal tells us the direction of the surface. A surface normal points perpendicular to the surface so a flat, level platform would
                //  have a surface normal of Vector2(0,1)
                //If we hit the top of a box, it will be Vector2(0,1)
                //If we hit the bottom of a box, it will be Vector2(0,-1)
                //If we hit the left side of a box, it will be Vector2(-1,0)
                //If we hit the right side of a box, it will be Vector2(1,0)
                Vector2 normal = cp.normal;

                if (normal.y > 0)
                {
                    //we hit the top side
                }
                else if (normal.y < 0)
                {
                    //we hit the bottom side
                }

                //Warning! If the collider you hit was a circle or polygon collider, the normal will be a range of values
            }
        }


        //These methods are called just like OnCollision but the Collider must be set to 'Trigger'
        //Remember, colliders set to Trigger will not collide with objects physically anymore but they can still detect things that touch them.
        //This is very useful for creating zones that open doors, start elevators, end the level, etc.
        //This is also useful for power-ups and collectibles!

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //If you have a script called Character with a variable called 'health', a health powerup might look like this...

            /*
            Character ch = collision.collider.GetComponent<Character>();
            if (ch != null)
            {
                ch.health += 5;
                Destroy(this.gameObject);
            }
            */


            //Because the collectible has been used up, we destroy it after it's added its health to the player.
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            
        }
    }
}
