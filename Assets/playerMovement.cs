//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class playerMovement : MonoBehaviour
{

    protected float speed = 2;
    protected float maxspeed = 10f;
    protected float Angle = 0f;
    protected Vector3 moving;
    protected Rigidbody CarRigidbody;
    void Start()
    {
        CarRigidbody = GetComponent<Rigidbody>();

    }
    private void Update()
    {
       
            
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(CarRigidbody.velocity.magnitude);

        float VerticalMove = Input.GetAxis("Vertical");
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {

            if (Math.Abs(Angle) < 40)
            {
                Angle += Input.GetAxis("Horizontal");
            }
        }
        else if (Math.Abs(Angle) < 1f)
        {
            Angle = 0;
        }
        else
        {
            Angle -= (Math.Abs(Angle) / Angle) / 2;
        }
         Move(VerticalMove, Angle);

       
        

    }

    void Move(float VerticalMove, float Angle)
    {



        if (VerticalMove > 0.1f )
        {
            CarRigidbody.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 10 * speed);
            
        }
        if (VerticalMove < -0.1f)
        {
            CarRigidbody.AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) *-10 * speed);
        }


        //Не пипай!!!
        //за изпипване на физиките!!!!
        //----------------------------------------------------------------------------------
        // CarRigidbody.MovePosition(transform.position+Vector3.forward*Time.deltaTime*speed);
        // CarRigidbody.MoveRotation(new Quaternion(0f, 0f, 0f, 0f));
        //transform.Rotate(0, Angle / 100, 0);
        //CarRigidbody.AddRelativeTorque(new Vector3(0,Angle,0));
        //CarRigidbody.velocity = Quaternion.Euler(0, Angle/10f, 0) * CarRigidbody.velocity;
        //(Input.GetAxis("Horizontal") * rotateSpeed
        transform.Rotate(0, Angle * Mathf.Abs(VerticalMove*0.1f), 0);
        
    }

}

