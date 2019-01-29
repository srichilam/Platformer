using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpPower; 
    Rigidbody rb; 

    // Use this for initialization 
	void Start () {
        rb = GetComponent<Rigidbody>(); 
		
	}
	
	// Update is called once per frame
	void Update () {
        float xVelocity = speed * Input.GetAxis("Horizontal");
        float yVelocity = rb.velocity.y; 
        if (Input.GetAxis("Vertical") > 0 && IsGrounded()) 
        {
            yVelocity = jumpPower; 
        }
        Vector3 velocity = new Vector3(xVelocity, yVelocity, 0);
        rb.velocity = velocity;	
	}

    bool IsGrounded() 
    {
        int layerMask = LayerMask.GetMask("Platform");
        return Physics.Raycast(transform.position, Vector3.down, 0.6f, layerMask); 
    }
}