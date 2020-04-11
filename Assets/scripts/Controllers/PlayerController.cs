using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //----------------------------------------------------------
    // VARIABLES BELOW:
    //----------------------------------------------------------
    Camera cam;
    public LayerMask movementMask;
    float speed = 4;       //general speed
    float rotSpeed = 80; //rotation speed
    float rot = 0f;
    float gravity = 8;
    private AudioSource audioSound; // for attacking audio sword sound

    Vector3 moveDir = Vector3.zero; //same as saying (0,0,0)

    CharacterController controller;
    Animator anim;

	//----------------------------------------------------------
    // START BELOW:
    //----------------------------------------------------------
	void Start ()
    {
        cam=Camera.main;
        //referenced animator and controller on player below:
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioSound = GetComponent<AudioSource>(); // to play attacking sword sound

	}
    //----------------------------------------------------------
    // UPDATE BELOW:// Update is called once per frame
    //----------------------------------------------------------
    void Update()
    {
        Movement();
        GetInput();

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit,100,movementMask))
            {
                Debug.Log("We hit "+hit.collider.name+ " "+ hit.point);
                //move to what we hit

                //stop focusing on objects
            }

        }
        if(Input.GetMouseButtonDown(1))
        {
           

        }
    }
    //----------------------------------------------------------
    // MOVEMENT BELOW:
    //----------------------------------------------------------
    void Movement()
    {
        //isGrounded- if player is not falling or flying 
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W)) //if holding down the "w" button
            {
                if (anim.GetBool("attacking") == true) //check if you are attacking
                {
                    return;
                }
                else if (anim.GetBool("attacking") == false) //check if not attacking then want to move
                {
                    anim.SetBool("running", true); //setting the condition to determine (RUNNING)
                    anim.SetInteger("condition", 1);// this sets the condition to 1 to start animation
                    moveDir = new Vector3(0, 0, 1);
                    moveDir = moveDir * speed;
                    moveDir = transform.TransformDirection(moveDir); //u can rotate and move in that direction
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("running", false); //setting the condition to determine (NOT RUNNING)
                anim.SetInteger("condition", 0);// this sets the condition to 0 to go back to idle animation
                moveDir = new Vector3(0, 0, 0);
            }
        }

        //controls the rotation of the character
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime; //up and down axis gravity..lowering character to the ground.
        controller.Move(moveDir * Time.deltaTime);


    }
    //----------------------------------------------------------
    // GETINPUT BELOW:
    //----------------------------------------------------------
    void GetInput()
    {
        if (controller.isGrounded)
        {
            if(Input.GetMouseButtonDown(0)) //0 means left mouse button
            {
                if (anim.GetBool("running") == true) 
                {
                    anim.SetBool("running", false);//if running stop running 
                    anim.SetInteger("condition", 0); //set the state to condition 0 which is idle
                }
                if (anim.GetBool("running") == false)
                {
                   Attacking();
                }      
            }
        }
    }
    //----------------------------------------------------------
    // ATTACKING BELOW:
    //----------------------------------------------------------
    void Attacking()
    {
        StartCoroutine (AttackRoutine());
        audioSound.Play();//play sword attack sound!
    }

    //----------------------------------------------------------
    // IENUMERATOR BELOW:
    //----------------------------------------------------------
    IEnumerator AttackRoutine()//Coroutine with IEnumerator - the ability to wait and resume from same point .
    {
        anim.SetBool("attacking", true); //set the bool condition value to true
        anim.SetInteger("condition", 2); //set condition to 2 so start attacking!
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0); //set state condition to be 0 (idle)
        anim.SetBool("attacking", false);//set the bool condition value to false

    }
    



}

