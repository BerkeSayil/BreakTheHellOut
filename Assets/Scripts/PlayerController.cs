using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 18f;
    float gravity = -19.62f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float jumpHeight = 3f;
    
    [SerializeField] float dashSpeed = 50f;
    [SerializeField] ParticleSystem dashWind;

    [SerializeField]LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    [SerializeField] GameObject lazerTouched;
    //wallrunnning
    [SerializeField] Transform leftCheck, rightCheck;
    [SerializeField] LayerMask wallMask;
    [SerializeField] float wallSlideSpeed;
    bool isWallRight, isWallLeft;
    

    Vector3 move;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //stick ground
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        move = transform.right * x  + transform.forward * y;

        //dashing
        if (Input.GetButtonDown("Fire3"))
        {
            move += transform.forward * dashSpeed;
            dashWind.Play();
        }
        // delta y = 1/2 g t^2 timeDeltaTime 
        velocity.y += gravity * Time.deltaTime;

        //wallrun
        CheckForWall();
        WallSlideInput();

        controller.Move(move * speed * Time.deltaTime);
        
        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }

    }


    private void WallSlideInput()
    {
        if(Input.GetKey(KeyCode.A) && isWallLeft)
        {
            WallSlide();
        }
        if (Input.GetKey(KeyCode.D) && isWallRight)
        {
            WallSlide();
        }
    }
    private void WallSlide()
    {
        velocity.y = 0;
        gravity = 0f;

        //make player stick to wall
        if (isWallLeft)
        {
            move += transform.right * wallSlideSpeed * -1;
        }
        if(isWallRight)
        {
            move += transform.right * wallSlideSpeed;
        }

    }
    private void CheckForWall()
    {
        isWallLeft = Physics.CheckSphere(leftCheck.position, groundDistance, wallMask);
        isWallRight = Physics.CheckSphere(rightCheck.position, groundDistance, wallMask);

        if(!isWallLeft && !isWallRight)
        {
            gravity = -19.62f;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lazer"))
        {
            lazerTouched.SetActive(true);
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.buildIndex);
        }
    }

}
