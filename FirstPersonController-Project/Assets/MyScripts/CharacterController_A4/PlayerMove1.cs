using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    //This script allows us to add character movement to our object(i.e robot)
    public float speed;
    public float gravity; //use instead of rigidbody component
    public float jumpHeight; //use to make object jump
    
    //use these variables for checking jump (prevent multiple jumps - flying)
    public LayerMask ground; //for the ground(i.e. terrain, plain, etc), assign layer = "ground" 
    public Transform feet; //assign our object('Feet') to the Move1 component of "Feet" 
    //feet object must be initiated to position(0,-1,0) after assigned as child to object
    
    private Vector3 direction;
    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity; 
 
    private CharacterController controller; 

    //for double jump
    private int doubleJump = 0; 

    //audio when jumping, audio source
    private new AudioSource audio; 

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f; //initial speed is 5.0
        gravity = 9.8f; 
        jumpHeight = 4.0f; //initial number is 3.0

        direction = Vector3.zero; 

        walkingVelocity = Vector3.zero;
        fallingVelocity = Vector3.zero;

        controller = GetComponent<CharacterController>(); //use to assign character controller
        //under 'component' tab, select physics, then select 'character controller' to add component to object

        audio = GetComponent<AudioSource>(); 

    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal"); //left and right
        direction.z = Input.GetAxis("Vertical");   //up and down
        direction = direction.normalized; 
        
        //use to face moving direction
        if(direction != Vector3.zero)   //if direction doesn't equal zero
            transform.forward = direction;
        walkingVelocity = direction * speed; 
        controller.Move(walkingVelocity * Time.deltaTime); //time between two frames

        //simulate gravity
        fallingVelocity.y -= gravity * Time.deltaTime; 

        //bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground); //use this function, to check feet distance and ground
        //if distance between feet and ground is smaller than 0.1, then return true, otherwise return false 

        //update isGrounded to a function, for double jump
        bool isGrounded() 
        { 
            if(Physics.CheckSphere(feet.position, 0.1f, ground))
            {
                doubleJump = 0;
                return true;
            }    
            else
            {
                return false; 
            }
        }


        //use for jump
        //if user presses jump, and is on ground(smaller than 0.1), then we can jump
        if(Input.GetButtonDown("Jump") && (isGrounded() || doubleJump < 2))  
        {
            audio.Play();  //play sound when press jump
            
            doubleJump +=1;

            //if user types/presses the jump button(i.e. space button)
            fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight); 

            //otherwise, it's a negative number
        }

        controller.Move(fallingVelocity * Time.deltaTime); //use to move object on the Y-axis

    }
}
