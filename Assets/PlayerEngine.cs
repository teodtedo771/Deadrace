using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEngine : MonoBehaviour
{

    public float speed = 10;
    private float Angle = 0f;
    private Rigidbody CarRigidbody;
    void Start()
    {
        CarRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float HorizontalMove = Input.GetAxis("Horizontal");
        if (Math.Abs(Input.GetAxis("Vertical")) > 0.1)
        {

            if (Math.Abs(Angle) < 80)
            {
                Angle += Input.GetAxis("Vertical");
            }
        }
        else
        {
            Angle -= Math.Abs(Angle) / Angle;
        }
        Move(HorizontalMove, Angle);
    }

    private void Move(float HorizontalMove, float VerticalMove)
    {
        Vector3 movement = new Vector3(HorizontalMove, 0, 0);
        movement *= speed * Time.deltaTime;
        CarRigidbody.MovePosition(transform.position + movement);
        CarRigidbody.MoveRotation(new Quaternion(transform.rotation.x, transform.rotation.y + Angle / 10, transform.rotation.z, transform.rotation.w));
    }

}
