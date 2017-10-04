using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 10;
    public float jumpSpeed = 10;
    public bool canMoveLeft;
    public bool canMoveRight;
    public bool canJump;
    public bool canDoubleJump;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        canMoveRight = true;
        canMoveLeft = true;
	}
    
    // Update is called once per frame
    void Update () {


        if (Input.GetKey(KeyCode.A) && canMoveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) && !canMoveLeft)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D) && canMoveRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        } else if (Input.GetKey(KeyCode.D) && !canMoveRight)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && (canJump ||canDoubleJump))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            if (!canJump) canDoubleJump = false;
        }
        Debug.Log("Can Move Right? " + canMoveRight.ToString() + "  X: " + rb.velocity.x + "   y:" + rb.velocity.y);
    }
}
