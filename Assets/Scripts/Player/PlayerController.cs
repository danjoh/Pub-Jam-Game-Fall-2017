using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 8;
    public float jumpSpeed = 20;
    public bool canMoveLeft;
    public bool canMoveRight;
    public bool canJump;
    public bool canDoubleJump;
    public string currentMagic;
    public Rigidbody2D rb;
    public string nextSpell;
    GameObject magicGameObject;
    Sprite water, fire, earth, air, lightSprite, dark, life, death;
    SpriteRenderer magicSpriteRenderer;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        canMoveRight = true;
        canMoveLeft = true;
        currentMagic = "";
        nextSpell = "";
        magicGameObject = GameObject.Find("MagicPrepped");
        water = Resources.Load("Water", typeof(Sprite)) as Sprite;
        fire = Resources.Load("Fire", typeof(Sprite)) as Sprite;
        earth = Resources.Load("Earth", typeof(Sprite)) as Sprite;
        air = Resources.Load("Air", typeof(Sprite)) as Sprite;
        life = Resources.Load("Life", typeof(Sprite)) as Sprite;
        death = Resources.Load("Death", typeof(Sprite)) as Sprite;
        magicSpriteRenderer = magicGameObject.GetComponent<SpriteRenderer>();
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

        //DO MAGICS
        if (Input.GetMouseButtonDown(1) && currentMagic.Length > 0) {
            nextSpell = currentMagic;
            Debug.Log(nextSpell);
            if (nextSpell == "water")
                magicSpriteRenderer.sprite = water;
            else if (nextSpell == "fire")
                magicSpriteRenderer.sprite = fire;
            else if (nextSpell == "earth")
                magicSpriteRenderer.sprite = earth;
            else if (nextSpell == "air")
                magicSpriteRenderer.sprite = air;
            else if (nextSpell == "life")
                magicSpriteRenderer.sprite = life;
            else if (nextSpell == "death")
                magicSpriteRenderer.sprite = death;
        }
        if (Input.GetMouseButtonDown(0) && nextSpell.Length > 0)
        {
            nextSpell = "";
            magicSpriteRenderer.sprite = null;
        }
    }
}
