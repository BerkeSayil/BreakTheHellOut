using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpSpeed = 200f;
    CharacterController controller;

    [SerializeField] float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    Vector3 playerVelocity;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }


    private void FixedUpdate()
    {
        //forward backward move
        Vector3 vertical = transform.TransformDirection(Vector3.forward);
        float currentSpeedV = speed * Input.GetAxis("Vertical");
        controller.Move(vertical * currentSpeedV * Time.deltaTime);

        //left right walk
        Vector3 horizontal = transform.TransformDirection(Vector3.right);
        float currentSpeedH = speed * Input.GetAxis("Horizontal");

        controller.Move(horizontal * currentSpeedH * Time.deltaTime);


    }

    private void Update()
    {
        
        Look();
        


    }

    private void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        Cursor.visible = false;
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

    
}
