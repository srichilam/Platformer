using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public enum Direction { left, right };
    public Direction direction; 
    public float speed;

    Rigidbody rb;

    int layerMask; 

	// Use this for initialization
	void Start () {
        if (direction == Direction.right) 
        {
            transform.Rotate(0, 0, -90); 
        }
        else 
        {
            transform.Rotate(0, 0, 90);
            speed *= -1; 
        }
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        layerMask = LayerMask.GetMask("Platform"); 
	}
	
	// Update is called once per frame
    void Update () {
        if (Physics.Raycast(transform.position, transform.up, 0.6f, layerMask)) 
        {
            transform.Rotate(0, 0, 180);
            speed *= -1;
            rb.velocity = new Vector3(speed, rb.velocity.y, 0); 
        }
	}
}
