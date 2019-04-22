using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class HealthandDeath : MonoBehaviour
    {
        public int maxHealth;
        public int theDamage;
        public static int theBatLives = 3;
        public bool IsHitForHealthBar;

        void Start()
        {

        }


        public virtual void Death()
        {
          Destroy(gameObject);
        }

    }

