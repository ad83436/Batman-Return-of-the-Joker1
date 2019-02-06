//These are 'using' statements. They must always be at the top and let you use classes in that namespace without the full name.
//  If you didn't have 'using UnityEngine', you would have to write UnityEngine.MonoBehavior, for example
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a Namespace. Anything within the curly braces of a namespace is contained in that namespace. 
//  So the CodeExamples class is in the Examples namespace. Only some things can go in a namespace, like classes, while variables cannot go in a namespace.
namespace Examples
{


    //This is a class. Classes are usually public but can be private for special cases. Public means it can be seen and used in all other classes.
    //  The ':' means inherit. The name after the ':' is the class to be inherited. If you inherit MonoBehavior, that makes your class a Component.
    //  Inheriting MonoBehavior allows you to add this class to a gameobject in the UnityEditor. You must inherit MonoBehavior if you want to add
    //  your class to a gameobject! Inheriting Monobehavior is also the default when you make a new script in the Unity editor.
    public class ExampleComponent : MonoBehaviour
    {
        //---------------INSTANCE VARIABLES--------------//

        //Variables inside the class curly braces but outside method curly braces are special.
        //These variables are instance variables. They can be used in methods and keep their value for as long as the instance exists.

        //These instance variables are public. That means they can be seen in the Editor *if* this class inherits MonoBehavior
        //  They are also visible to other classes if they have a reference to this instance.
        public int IntegerVariableVisibleInTheEditor;
        public Vector2 VectorVariable;
        public string NameForThisObject;
        public float WalkForce;

        //This is one way to connect other game objects in your scene. You can drag and drop in the editor onto this variable in the inspector.
        public GameObject ReferenceToAnotherGameObject;

        //These are private instance variables. They can only be used inside this class.
        //  You can store values and references to other gameojects and reference to components on the same gameobject.
        private int counter;
        private float timer;

        private Animator anim;
        private Rigidbody2D rbody;
        private SpriteRenderer srenderer;

        private GameObject someOtherGameObject;

        //--------------MONOBEHAVIOR METHODS---------------//

        //Start is a special method inherited from MonoBehavior. That means it will be called by Unity.
        //Don't forget to add this Component to a gameobject in the editor! Start() will not do anything if you forget to add this class as a component in the editor.
        void Start()
        {
            //Your code should be added here, between the curly braces {}
            //Most lines with code that you write should end in a semicolon ;
            //Lines of code with if/switch/for should end in an open curly brace {
            //Open curly braces { need to have a matching closed curly brace } at some point, either on the same line or lower down.
            //Empty lines don't need anything
            

            //------------LOCAL VARIABLES-----------//
            //Variables written inside a method are 'local' variables. They are written bewteen the curly braces {} of a method. 
            //Once the method is finished, these variables lose their stored values. When you run the method again, the variables start over.
            //If you need to store something for after the method ends, either 'return' the value or store it in an instance variable.

            //integer variable - stores both positive and negative numbers
            int i = 5;

            //float variable - stores positive and negative decimal numbers (don't forget the 'f' at the end)!
            float f = 5.3f;

            //double variable - same as float but uses more memory and has more precision (Unity prefers floats)
            double d = 5.3;

            //boolean variable - stores true or false
            bool b = true;

            //string variable - stores entire words or sentences (don't forget to "quote the words")
            string s = "hello world";

            //char variable - stores only a single character. More efficient than string if you only need 1 character. (don't forget the single quotes '!')
            char c = 'j';

            //object variable - stores anything! Less efficient than using the specific type. If you need to store only integers, use int.
            object o = null;
            o = i;
            o = f;
            o = s;
            o = new GameObject();

            //Object variable - what's the difference? Big O Object means no primitive types (int, float, char, etc). Don't get caught by the difference!
            Object bigO = null;
            //bigO = i;             //This won't compile!
            //bigO = f;             //This won't compile!
            //bigO = s;             //This won't compile!
            bigO = new GameObject();


            //--------VARIABLE NAMES----------//
            //Give your variables good names that describe what they contain. Don't make them super long. Try to strike a good balance between
            // short and descriptive

            int x = 0; //What is x? This might be ok for a loop but it's a terrible name for anything more complicated
            int thisIsAVariableNameThatContainsAnIntegerWhichIsUsedInStart = 0; //Not a good name either...
            int counter = 0; //better
            int cnt = 0; //also ok

            //Whatever you name your variables and your methods, it should have a consistent style
            int thisIsCamelCase = 0;
            int this_is_snake_case = 0;
            
            //there's also hungarian notation and a variety of others. Pick your favorite and stick to it! If you change your mind half way through, go back
            //  and change your old variable/method names to match.



            //------------METHOD CALLS-----------------//

            //This is a method call. This will run all the lines of code in the 'Method1' method written below.
            ExampleMethod();

            //This is also a method call. It has a single int parameter, so you must write Method2( *some int value* )
            //  This method has a return type of string. That means the method must provide a string once it's finished, 
            //  so you can use can store that value in a string variable.
            string result = AnotherExampleMethod(5);

            //Calling Method3 and giving it a new GameObject instance.
            SaveGameObject(new GameObject());  
            
            //Calling Method3 and giving it 'this' gameObject, the gameObject this ExampleComponent component is attached to.
            SaveGameObject(this.gameObject);   
            
            //Calling Method3 and giving it the gameObject reference set in the editor. Could be null!
            SaveGameObject(ReferenceToAnotherGameObject);


            //------------INSTANCE VARIABLES--------------//
            //Get references to other components and store them in instance variables
            //You can't use a component without having a reference to it!
            //Instance variables let you share things across methods
            //Store references to components in Start() and use those references in Update
            anim = GetComponent<Animator>();
            rbody = GetComponent<Rigidbody2D>();
            srenderer = GetComponent<SpriteRenderer>();

            //You can also lookup gameobjects in the scene by name.
            //Be careful! If the gameobject you're looking for was destroyed or hasn't been created yet, you will get a null reference.
            //Also, be careful! If you mispell the name of the gameobject, you will get null.
            //GameObject.Find is a little bit dangerous so don't make it your first choice for getting references to other gameobjects.
            someOtherGameObject = GameObject.Find("NameOfGameObject");
        }


        //This is an Update method. It is 'inherited' from MonoBehavior. Unity will call this method for you once per frame.
        //  If you're game is running at 30 frames per second, this method will happen 30 times per second.
        void Update()
        {
            //------------CONTROL STATEMENTS--------//

            //'if' statements are extremely important and helpful. Especially in Update(). Update happens every frame, so if you want to wait for something
            //  and run some code when it happens, use an if statement inside Update.

            int i = 7;
            bool b = false;
            if (b)  //round brackets () for true or false expression, curly brackets {} for code
            {
                //Do something only if b is true
            }
            else if (i < 10) //i < 10 is a boolean expression. where i is 10 or greater, (i < 10) will be false. where i is 9 or less, (i < 10) will be true
            {
                //Do something if b is false and if i is less than 10
            }
            else
            {
                //Do something if b is false and if i is greater or equal to 10
            }

            //We can use if statements to check if we have references or nulls
            //  -  If you forget to drag and drop in the editor, a public instance variable will be null.
            //  -  If you use GameObject.Find, the result could be null
            //  -  If you write an instance variable but never use it, the default value is null.
            if (someOtherGameObject != null)
            {
                //Now we know for sure that 'someOtherGameObject' contains a reference to a gameobject and not a null, so it's safe to use this variable
                someOtherGameObject.SetActive(false);
            }
            else
            {
                //this code happens if 'someOtherGameObject' contains null so we could, for example, try and fix it
                someOtherGameObject = GameObject.Find("NameOfGameObject");
            }

            //-----------INPUT-----------//
            
            //Input.GetKey lets you detect keypresses directly in code

            if (Input.GetKey(KeyCode.Space)) //Will be true anytime spacebar button is down
            {
                //This code will run when the spacebar is pressed. (Because Update runs every frame, this will run every frame that spacebar is held down)
            }

            if (Input.GetKeyDown(KeyCode.Space)) //Will be true *only once* after spacebar is pressed. After spacebar is released, can trigger again on next press.
            {
                //This code will run once after spacebar is pressed.
            }

            if (Input.GetKeyUp(KeyCode.Space)) //Will be true *only once* after spacebar is released.
            {
                //This code will run once spacebar is released.
            }


            //Input.GetButton lets you detect when the input assigned to "Jump" in the Input Manager panel under Project Settings.
            //Input.GetButtonUp and Input.GetButtonDown are also available, just like GetKeyUp/GetKeyDown

            if (Input.GetButtonDown("Jump"))
            {
                //This code will run once the spacebar is pressed or the 'A' key on an xbox controller is pressed because those keys are assigned
            }

            //To get movement values, use Input.GetAxis instead of Input.GetButton

            //THIS WON'T WORK!
            //if (Input.GetAxis("Horizontal")) 
            //{

            //}

            //Input.GetAxis returns a float value from -1.0f to 1.0f. If you're using an analog stick, like on an xbox controller, this will be a range
            //  of values between -1 and 1. If you're using arrow keys on a keyboard, it will only be -1, 0, 1. This is why it's important to use
            //  comparison instead of equals. Don't write 'if (x_axis_value == 1.0f)'. In general, it's usually a bad idea to use '==' with floats.
            float x_axis_value = Input.GetAxis("Horizontal");
            float y_axis_value = Input.GetAxis("Vertical");     //You probably won't need this one for your game.

            if (x_axis_value < 0.0f)
            {
                //Move left
            }

            if (x_axis_value > 0.0f)
            {
                //Move right
            }

            if (x_axis_value == 0.0f)
            {
                //Do nothing (you don't need to write this if statement since it does nothing anyway)
            }

        }



        //---------YOUR METHODS-----------//

        //This is a basic method. Methods allow you to run some code by 'calling' the method by name.
        // 'private' is an access modifier. If a method is private, it can only be used inside the class.
        // 'void' is a return type. Void means this method returns nothing when it's finished.
        //  Name your method something that describes what it does.
        private void ExampleMethod()
        {
            //write some code here
        }

        //This is another type of method. It has a parameter 'i' which is a variable that's only usable in this method.
        //The parameter 'i' stores a value that's provided when you call this method. If you wrote AnotherExampleMethod(5) in Start() then 'i' would be set to 5
        //'string' is it's return type. This means that you must have a line of code that returns a value of this type. 
        //  eg. return 5 for int, return "hello" for string
        //Returning a value ends the method. If you have lines of code after a return, they won't run.
        public string AnotherExampleMethod(int i)
        {
            //strings can 'add' things to it. This means the string will add the value as a string.
            //  if the variable i was 5, the variable s would contain "hello 5"
            string s = "hello " + i; 

            //This line is required if method return type isn't void. It must also return a matching value, in this case, a string
            return s;
        }

        //Methods can also use instance variables defined outside the method. This method stores the GameObject given to it through the gameObject parameter
        //  in an instance variable
        public void SaveGameObject(GameObject gameObject)
        {
            //instance variables can be used in methods. This is a great way to store values that you want to keep for later.
            ReferenceToAnotherGameObject = gameObject;
        }


        //You can also overload methods. This means you can write multiple methods with the same name if they have different parameters.
        //By different parameters, I mean either a different number of parameters or parameters with different types. NOT parameters with different names.
        public void MethodOverloaded(int i)
        {
        }
        public void MethodOverloaded(string s)
        {
        }
        public void MethodOverloaded(int i, string s)
        {
        }
        //public void MethodOverloaded(int cnt, string name) //This won't compile! Different names don't count for overloading, only different types or different number of params.
        //{
        //}

        //Overloading is useful when you want multiple methods that all do very similar things but with different options in their parameters.
        public void FireWeapon(int shotCount)
        {
        }
        public void FireWeapon(int shotCount, Color projectileColor)
        {
        }


        //--------------USING COMPONENTS------------//

        public void TriggerMyJumpAnimation()
        {
            //To control you animations, you need to a reference to the Animator component. In Start(), we stored a reference in the 'anim' instance variable.

            //Animator has methods to set Parameter values you set up in Animator editor.
            //These methods let you set these values to control transitions between your animations.
            //By themselves, these methods do nothing! You must set your Transitions to use the Parameters as Conditions. Check Week 3 slides for review.
            //Remember, you don't run animations from code, you control transitions from code. The Animator runs the animations.
            anim.SetBool("ParameterNameInTheAnimator", true);
            anim.SetInteger("IntParmater", 5);
            anim.SetFloat("FloatParam", 5.3f);
            
            //Triggers don't have a value associated with them. Transitions that use triggers will fire after this method is used.
            //Don't confuse animation triggers with physics triggers!
            anim.SetTrigger("TriggerParam");        

            //The Animator component has lots of other methods, feel free to explore but these top 4 are the most important.
        }
        

        private void MoveMyCharacter()
        {
            float xAxisInput = Input.GetAxis("Horizontal");

            //A Vector2 value contains an x and a y value. 
            float x = WalkForce * xAxisInput;
            float y = 0;
            Vector2 moveForce = new Vector2(x, y); //x pushes to the right, y pushes upward
            moveForce = new Vector2(-x, -y); //-x pushes to the left, -y pushes downward

            //Using Vector2 for force means x is a force value pushing horizontally, y pushes vertically.
            rbody.AddForce(moveForce, ForceMode2D.Force);

            //You can read the velocity of your gameobject to track how fast your object is moving.
            Debug.Log(rbody.velocity);

            //You can also set the velocity directly to make an object move at a constant speed
            rbody.velocity = moveForce;
        }

        private void JumpAction()
        {
            if (Input.GetButtonDown("Jump"))
            {
                //Pushes this gameobject up with a force of 5 units per second. 
                //Impulse mode is better for single bursts of force, like a jump or a hit.
                //Force mode is better for sustained application of force, like runnning force or force propelling a missile.
                rbody.AddForce(new Vector2(0,5), ForceMode2D.Impulse);
            }
        }
    }



    //You can define more than one class in a single file. Don't overdue it though! It's good practice to keep most classes in their own script file.
    //  This class does not inherit anything. This means there's no Start() or Update(). It will only have the methods or instance variables you give it.
    //  You could write your own Start() or Update() method but it will not be called by Unity!
    public class MyClass
    {
        //Even though I added a Start() method, IT WILL NOT BE CALLED BY UNITY! Class needs to inherit MonoBehavior for that to work.
        void Start()
        {

        }
    }
}
