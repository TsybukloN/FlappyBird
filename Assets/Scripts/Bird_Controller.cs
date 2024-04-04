using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Controller : MonoBehaviour
{
    public Rigidbody2D rigi;
    public float jumpForce;

    void Start()
    {
        Debug.Log("Starting of controlling");  
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //animator.SetBool("Jump", true);
            rigi.velocity = new Vector2(rigi.velocity.x, jumpForce);
        }
        else
        {
            //animator.SetBool("Jump", false);
        }
    }
}
