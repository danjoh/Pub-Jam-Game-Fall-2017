using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour {
    public GameObject player;
    public PlayerController pCtrl;
    public float aggroDistance = 30.0f;
    private float enemyPositionX;
    private float playerPositionX;
    public float movementSpeed = 2.0f;
    public float currentSpeed;
    public float maxSpeed = 7.0f;
    float distance;
    bool goingLeft;
    //private Rigidbody2D playerRb;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pCtrl = player.GetComponent<PlayerController>();
        currentSpeed = movementSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "GroundCheck" || collision.name == "Player") {
            pCtrl.KnockBack(goingLeft).HurtPlayer(1);
            currentSpeed = movementSpeed;
        }
    }
    // Update is called once per frame
    void Update () {
        enemyPositionX = gameObject.transform.position.x;
        playerPositionX = player.transform.position.x;
        if (enemyPositionX > playerPositionX)
        {
            goingLeft = true;
            distance = Mathf.Abs(enemyPositionX - playerPositionX);
        }
        else
        {
            goingLeft = false;
            distance = Mathf.Abs(playerPositionX - enemyPositionX);
        }
        if (distance <= aggroDistance)
        {
            if ((goingLeft && rb.velocity.x > 0) || (!goingLeft && rb.velocity.x < 0)) currentSpeed = movementSpeed;
            currentSpeed += 1 * Time.deltaTime;
            rb.velocity = new Vector3((goingLeft ? -1 : 1) * Mathf.Min(currentSpeed, maxSpeed), rb.velocity.y);
        } else
        {
            currentSpeed = movementSpeed;
            rb.velocity = new Vector3(0, rb.velocity.y);
        }
        
	}
}
