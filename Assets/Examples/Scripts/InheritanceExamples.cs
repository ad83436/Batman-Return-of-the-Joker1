using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Examples of inheritance with simple C# classes, no Unity
namespace Examples.Inheritance
{
    public class MissileLauncher
    {
        private Missile missile;

        //Contructor Method
        //This is a special type of method that is called when you create an instance from a class.
        //Constructor methods have no return type and must have the same name as the class.
        //This method runs automatically when you write 'new MissileLauncher()'.
        //It's a great way to make sure all your instance variable are set correctly before the instance is used.
        //In this case, we want to start with a Missile already loaded, so we can make sure it's been added to the variable in the Constructor.
        //You can also add parameters to the constructor just like any other method.
        public MissileLauncher()
        {
            //Perfectly normal use of a variable and an instance of a class.
            missile = new Missile();

            //and when I call the Fire() method, it runs the Fire() method in the Missile class, just like normal.
            missile.Fire();

            //But we can also do this.
            missile = new HomingMissile();

            //Even though HomingMissile is not the same type as Missile, we can still store it in the 'missile' variable.
            //That's because anything that inherits from Missile is compatible with the Missile type. ie. A subtype.

            //If I call Fire() now, things get interesting. If I hadn't overridden the Fire() method in HomingMissile, it would still call the same Fire()
            //  method in the Missile class. However, because I did override Fire(), it will call the new Fire() method in HomingmMissile.
            missile.Fire();
            
            SwitchMissiles(); //Changes type of Missile stored in missile variable to ClusterMissile.

            missile.Fire(); //Exact same code runs Fire() in ClusterMissile class.
            
            SwitchMissiles(); //Changes type of Missile to regular Missile.

            missile.Fire(); //Exact same code runs Fire() in Missile class

            SwitchMissiles(); //Changes type of Missile back to HomingMissile.
            
            missile.Fire(); //Exact same code runs Fire() in HomingMissile class
        }


        //This method uses 'is' to check what's stored in 'missile'
        //Because we have subtypes now, we no longer know if it's a regular Missile or some subtype of Missile
        //We can check which type is stored in the variable by using 'is' and the name of the class.
        //Using 'is' results in a boolean value, true or false, which makes it perfect for if statements
        public void SwitchMissiles()
        {
            if (missile is Missile)
            {
                missile = new HomingMissile();
            }
            else if (missile is HomingMissile)
            {
                missile = new ClusterMissile();
            }
            else if (missile is ClusterMissile)
            {
                missile = new Missile();
            }
        }
    }

    //This is the more general class that we'll be specializing with inheritance.
    public class Missile
    {
        //Subclasses of Missile will also have this variable but won't be able to use it because it's marked private.
        private float missileSpeed = 0.5f;

        //'protected' is a special modifier that means private to everyone except subclasses.
        //Protected access is useful if you want to keep a variable encapsulated but you want subclasses to have more control over how this class functions.
        //Methods can also be marked protected.
        protected Color missileColor;

        //Notice the 'virtual' keyword here. Virtual is required if you want to override in a subclass.
        public virtual void Fire()
        {
            Debug.Log("Missile is firing!");
        }
    }

    //Both HomingMissile and DumbfireMissile inherit from Missile.
    //This means they gain the same variables and methods as the Missile class.
    //However, any variables or methods in Missile that are marked 'private' can't be used in subclasses.
    public class HomingMissile : Missile
    {
        //The overide modifier means we run this method instead of the Fire() method in the Missile base class. 
        public override void Fire()
        {
            //'base' is a reference to the Missile class we inherited from. If we override Fire() but also want to use the original Fire() from Missile, we need base.
            base.Fire();
            Debug.Log("Missile is tracking target.");
            //Debug.Log(missileSpeed); //This won't compile! This class does still inherit the missileSpeed variable but it's not allowed to access it.

        }

        public void Homing()
        {
            //Because HomingMissile has access to missileColor in the Missile base class, it can use missileColor to show it's tracking a target
            missileColor = Color.red;
        }
    }

    public class ClusterMissile : Missile
    {
        public override void Fire()
        {
            base.Fire();
            Debug.Log("Missile cluster mode armed.");
        }
    }
    
}

