//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class playerMovement : MonoBehaviour
{
  
    public float speed = 0;
    private float Angle = 0f;
    private Rigidbody CarRigidbody;
    void Start()
    {
        CarRigidbody = GetComponent<Rigidbody>();
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float VerticalMove = Input.GetAxis("Vertical");
      
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {

            if (Math.Abs(Angle) < 80)
            {
                Angle += Input.GetAxis("Horizontal");
            }
        }
        else if (Math.Abs(Angle) < 0.5f)
        {
            Angle = 0;
        }
        else
        {
            Angle -= (Math.Abs(Angle) / Angle) / 2;
        }
        Move(VerticalMove, Angle);
    }

    private void Move(float VerticalMove, float Angle)
    {
        Console.WriteLine(Input.GetAxis("Vertical"));

        if (Math.Abs(Input.GetAxis("Vertical")) < 0.1f)
        {
            if (speed > 0.2f)
            {
                speed -= 0.2f;
            }
            else
            {
                speed = 0;
            }
        }

        if (Math.Abs(Input.GetAxis("Vertical")) > 0.1f && speed < 10f) {
            speed+=0.2f;

        }


        if (speed < 40) { speed += 0.2f; }
         CarRigidbody.MovePosition(transform.position+Vector3.forward*Time.deltaTime*speed);
        // CarRigidbody.MoveRotation(new Quaternion(0f, 0f, 0f, 0f));
        transform.Rotate(0, Angle, 0);


       
    }

}

