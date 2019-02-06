using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Composition
{
    //A simple composition example class
    //The Missile class uses other classes to handle some of the work
    //Those helper classes are stored in private variables so only the Missile class can control them.
    //This way you can 'compose' your class from other classes. The details of using the helper classes are hidden inside the Missile class.
    //Because the classes used internally are only visible internally, using the Missile class is much easier than writing it.
    //That's the point of encapsulation (making things private). Easier to use than to write. If you find using a class is complicated, try to do more encapsulation.
    public class Missile
    {
        private HomingModule homingModule;
        private EngineModule engine;

        public Missile(bool isHomingMissile)
        {
            homingModule = new HomingModule();
            homingModule.Enabled = isHomingMissile;

            engine = new EngineModule();
            engine.Active = false;
        }

        public void Fire()
        {
            Debug.Log("Missile is firing!");

            if (homingModule.Enabled)
            {
                homingModule.TrackTarget();
            }
            else
            {
                Debug.Log("Missile is moving straight.");
            }
        }

        public void StartEngine()
        {
            engine.Active = true;
            engine.MissileSpeed = 7.2f;
        }
    }

    //These classes are created to be used by Missile class internally.
    //If you're working on a class that has gotten very big, consider writing extra classes to handle some of the work and use them in the big class.
    //That doesn't mean you can't use these Module classes in a different class. You absolutely can!
    //In fact, if you have a good collection of Module classes, then you can make new classes by just combining a bunch of existing Module classes.
    //That's composition.

    public class HomingModule
    {
        public bool Enabled;

        public void TrackTarget()
        {
            Debug.Log("Missile is tracking target.");
            
        }
    }
    
    public class EngineModule
    {
        public float MissileSpeed;
        public bool Active;
    }
}
