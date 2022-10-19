using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* TASK: Comment on the code as we go through it
* Here we are doing Movement and Jumping
* Manipulate this script to add in a Jump function
* Extra Task: Add in Crouch or Sprint functions (or both)
*/

public class FPS_Movement : MonoBehaviour
{
    public float walkSpeed; //What's this for? Value for walk speed for the player. Float allows decimal.
    public float runSpeed;
    public float jumpHeight; //What's this for? Jump hieght as float for refinement.
    private float gravity = -10.81f; //What's this for? really???
    private CharacterController controller; //What's this for? Helps make movement easier and gives some tools
    private Vector3 velocity; //What's this for? The axis for the velocity to be applied on 
    private Vector3 moveDirection; //What's this for? The axis of movement
    bool isGrounded;
    public LayerMask GroundMask;

    void Start()
    {
        controller = GetComponent<CharacterController>(); //What's this for? Gets the character component
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){ //Controller has its own isGrounded function
            Jumping(); // calls the jump void
            //Debug.Log("Player has jumped");
        }

        /* if(Input.GetKey(KeyCode.LeftShift) && controller.isGrounded){ //Controller has its own isGrounded function
            Running(); // calls the running void
            //Debug.Log("Player is running");
        } */
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1.08f, GroundMask)){
            isGrounded = true;
        } else{
            isGrounded = false;
        }

        //Test area

        //Debug.Log(velocity.y);

        if(velocity.y <= -9.81f){
            velocity.y = 0;
        }

    }
    
    void FixedUpdate()
    {
        Walking(); //Why do we use fixed update for this? Calls the walking void below. Putting this in Fixed limits the times the void is played. Stops players
        Debug.Log(isGrounded);
    }

    void Walking()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); //What's this for? side to side movement
        float moveVertical = Input.GetAxisRaw("Vertical");   //What's this for? back and forth movement
        controller.Move(moveDirection * walkSpeed * Time.deltaTime);  //What's this for?  
        moveDirection = (moveHorizontal * transform.right + moveVertical * transform.forward); //What's this for? idk
        velocity.y += gravity * Time.deltaTime; //What's this for? idk
        controller.Move(velocity * Time.deltaTime); //What's this for? idk

        if(Input.GetKey(KeyCode.LeftShift)){
            controller.Move(moveDirection * runSpeed * Time.deltaTime);
        }
    }

    /* void Running(){
        controller.Move(moveDirection * walkSpeed * runSpeed * Time.deltaTime);
    } */

    void Jumping(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); // uses velocity and some maths idk to make player go up.
    }
}
