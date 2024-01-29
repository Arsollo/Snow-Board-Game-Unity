using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField] float torqueAmount = 20f;
    [SerializeField] float speed = 20f;

    bool canMove = true;



    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls()
    {
        canMove = false;
        surfaceEffector2D.speed = 5f;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed += 0.5f;
            surfaceEffector2D.speed = speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            speed -= 0.5f;
            surfaceEffector2D.speed = speed;
        }
    }

     void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);


        }
    }
}

