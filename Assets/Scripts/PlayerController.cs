using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 18f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float jumpHeight = 3f;
    
    [SerializeField] float dashSpeed = 50f;
    [SerializeField] ParticleSystem dashWind;

    [SerializeField]LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //wallrunnning
    [SerializeField] LayerMask wallMask;
    [SerializeField] float wallRunSpeed, maxWallRunTime;
    bool isWallRight, isWallLeft;
    bool isWallRunnning;
    [SerializeField] float wallRunCameraTilt;


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x  + transform.forward * y;

        //dashing
        if (Input.GetButtonDown("Fire3"))
        {
            move += transform.forward * dashSpeed;
            dashWind.Play();
        }
        //wallrun
        CheckForWall();
        WallRunInput();

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // delta y = 1/2 g t^2 timeDeltaTime squared
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }


    private void WallRunInput()
    {

    }
    private void StartWallRun()
    {

    }
    private void StopWallRun()
    {

    }
    private void CheckForWall()
    {

    }

}
