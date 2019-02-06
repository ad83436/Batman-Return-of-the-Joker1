using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    //Add this to any gameobject and set it's TimeUntilDeath in the inspector to kill an object after a certain amount of time.
    public class DeathTimerExample : MonoBehaviour
    {
        public float TimeUntilDeath;

        public float deathTimer;

        // Start is called before the first frame update
        void Start()
        {
            deathTimer = TimeUntilDeath;

            //Can also just use this but this way we can see the death timer in the inspector.
            //Can also modify this script to do other things after a timer runs out!
            /*
            Destroy(this, TimeUntilDeath);
            */
        }

        // Update is called once per frame
        void Update()
        {
            if (deathTimer > 0.0f)
            {
                deathTimer -= Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        //Resets death timer. Won't work if timer has already run out because gameobject will already be destroyed.
        public void KeepAlive()
        {
            deathTimer = TimeUntilDeath;
        }
    }
}
