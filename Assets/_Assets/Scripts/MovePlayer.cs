using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    //calling the input actions
    PlayerControls _playerControls;

    //define object to spawn and spawn location
    public GameObject objectToSpawn;
    public GameObject spawnPoint;

    //defines the move and rotate speed for the movement
    float moveSpeed = .1f;
    float turnSpeed = .5f;
    public float gravityValue = -0.25f;



    //[SerializeField] Quaternion currentRotation;
    public float rotationAmount;

    //defines the jump power
    [SerializeField] float jumpPower = 10f;

    //defines the rigidbody
    Rigidbody _body;

    //defines the animator
    Animator _anim;

    private void Awake()
    {
        //waking the input action
        _playerControls = new PlayerControls();

        //getting the rigibody
        _body = GetComponent<Rigidbody>();


        //getting the animator
        _anim = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        //enabling the input action on enable
        _playerControls.Enable();

        //subscribing the jump input
        _playerControls.Space.Jump.performed += onJump;

        //subscribing the spawn input
        _playerControls.Space.Spawn.performed += Spawn;

        //subscribing the grab input
        _playerControls.Space.Grab.performed += Grab;

        //subscribing the grab input
        _playerControls.Space.Release.performed += Release;

        //subscribing the float input
        _playerControls.Space.Floated.performed += Floated;
    }

    private void OnDisable()
    {
        //disabling the input action on disable
        _playerControls.Disable();

        //unsubscribing the jump input
        _playerControls.Space.Jump.performed -= onJump;

        //unsubscribing the spawn input
        _playerControls.Space.Spawn.performed -= Spawn;

        //unsubscribing the claw grab  input
        _playerControls.Space.Grab.performed -= Grab;

        //unsubscribing the claw release input
        _playerControls.Space.Release.performed -= Release;
        
        //unsubscribing the float input
        _playerControls.Space.Floated.performed -= Floated;

    }
    private void Spawn(InputAction.CallbackContext obj)
    {
        Instantiate(objectToSpawn, spawnPoint.transform);
    }

    private void onJump(InputAction.CallbackContext obj)
    {
        //add force to rigidbody
        //AddForce follow by Vector 3 (x, y, z); Vector3.up = Vector3 (0, 1, 0)
        //because onJump is a one time action, we use Impluse
        _body.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

    }

    private void Grab(InputAction.CallbackContext obj)
    {
        _anim.SetTrigger("grab");
    }

    private void Release(InputAction.CallbackContext obj)
    {
        _anim.SetTrigger("release");
    }

    private void Floated(InputAction.CallbackContext obj)
    {
        float antiGravity = _playerControls.Space.Floated.ReadValue<float>() * gravityValue * Time.deltaTime;
        Physics.gravity = new Vector3(0, antiGravity, 0);
    }



    // Update is called once per frame
    void Update()
    {
        //give the vector2 a name call "movement"
        //Vector 2 is two floats value; A and D is on X axis--1st float value, W and S is on Y axis--2nd float value;
        //float elevation is new y axis; 
        Vector2 movement = _playerControls.Space.Move.ReadValue<Vector2>() * moveSpeed * Time.deltaTime;

        float leftRightMovement = movement.x;

        float forwardBackwardMovement = movement.y;

        //give the float a name call "elevation"
        float elevation = _playerControls.Space.Elevate.ReadValue<float>() * moveSpeed * Time.deltaTime;
        transform.Translate(leftRightMovement, elevation, forwardBackwardMovement);

        //give the float a name call "antiGravity"
        //float antiGravity = _playerControls.Space.Floated.ReadValue<float>() * gravityValue * Time.deltaTime;
        //Physics.gravity = new Vector3(0, antiGravity, 0);
        

        //give the vector2 a name call "rotate"
        //turnSpeed and rotationAmount is defined at the beginning
        float rotate = _playerControls.Space.Rotate.ReadValue<float>() * turnSpeed * Time.deltaTime;
        transform.Rotate(0,rotate * rotationAmount, 0);


    }
}
