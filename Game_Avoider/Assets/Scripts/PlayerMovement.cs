using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

private Camera mainCam;
private Rigidbody rigidbody;

[SerializeField] private float forceMagnitude;
[SerializeField] private float MaxSpeed;

[SerializeField] private float RotationSpeed;

private Vector3 movementDirection;

    void Start()
    {
        mainCam = Camera.main;

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       processInput();

       KeepPlayerOnScreen();

       RotateToFaceVelocity();
    }

 
    private void FixedUpdate() 
    {
       AddForceToPlayer();
    }

    
    
    
    
    
    private void processInput()
    {
       if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

            //Debug.Log(touchPos);

            Vector3 WorldPos = mainCam.ScreenToWorldPoint(touchPos);

           // Debug.Log(WorldPos);

           movementDirection = transform.position - WorldPos;
           movementDirection.z = 0f;

           movementDirection.Normalize();
        }else
        {
            movementDirection = Vector3.zero;
        }
    }


    private void AddForceToPlayer()
    {
        if(movementDirection == Vector3.zero)
        {
            return;
        }

        rigidbody.AddForce(movementDirection * forceMagnitude, ForceMode.Force);
        
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, MaxSpeed);
    }
    

    
    private void KeepPlayerOnScreen()
    {
        Vector3 newPos = transform.position;

        Vector3 viewportPos = mainCam.WorldToViewportPoint(newPos);

        if(viewportPos.x > 1)
        {
           newPos.x = -newPos.x + 0.1f;
        }
        else if(viewportPos.x < 0)
        {
             newPos.x = -newPos.x - 0.1f;
        }

             if(viewportPos.y > 1)
        {
           newPos.y = -newPos.y + 0.1f;
        }
        else if(viewportPos.y < 0)
        {
             newPos.y = -newPos.y - 0.1f;
        }

        
        
        transform.position = newPos;
    }

   private void RotateToFaceVelocity()
    {
       if(rigidbody.velocity == Vector3.zero)
       {
           return;
       }

       Quaternion TargetRotation = Quaternion.LookRotation(rigidbody.velocity,Vector3.back);

       transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
    }



}
