using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Projectiles
{
    //You could add this code directly into your Character class 
    // or use this class as a 'module' inside your other classes
    public class ProjectileLauncher : MonoBehaviour
    {
        public GameObject ProjectilePrefab;
        public Vector2 ProjectileOffset;

        private bool IsGoingLeft;
        

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            //Basic character movement code
            float x_axis_value = Input.GetAxis("Horizontal");
            
            if (x_axis_value < 0.0f)
            {
                IsGoingLeft = true;
            }
            else if (x_axis_value > 0.0f)
            {
                IsGoingLeft = false;
            }
            else
            {
                //Standing still
            }


            if (Input.GetButtonDown("Fire1"))
            {
                LaunchProjectile();
            }
        }

        public void LaunchProjectile()
        {
            //Think about how to use IsGoingLeft to change direction of projectile. Remember if character is pointing left, projectile needs to shoot left

            GameObject prefab = GameObject.Instantiate<GameObject>(ProjectilePrefab);
            Projectile p = prefab.GetComponent<Projectile>();
            Vector2 pos = transform.position;
            pos += ProjectileOffset;
            p.StartingPosition = pos;
            p.StartingVelocity = new Vector2(1, 0);
        }
    }
}
