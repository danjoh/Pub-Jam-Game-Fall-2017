using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 8;
    public float jumpSpeed = 20;
    public bool canMoveLeft;
    public bool canMoveRight;
    public bool canJump;
    public bool canDoubleJump;
    Animator anim;
    public int health = 3;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public float immunityLength;
    public float immunityCount;

    public string currentMagic;
    public Rigidbody2D rb;
    public string nextSpell;
    GameObject magicGameObject;
    Sprite water, fire, earth, air, lightSprite, dark, life, death;
    SpriteRenderer magicSpriteRenderer;

    private List<GameObject> activeSpells = new List<GameObject>();

    public GameObject firePrefab;
    public GameObject waterPrefab;
    public GameObject earthPrefab;
    public GameObject airPrefab;
    public GameObject lifePrefab;
    public GameObject deathPrefab;
    public GameObject lightPrefab;
    public GameObject darkPrefab;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        canMoveRight = true;
        canMoveLeft = true;
        currentMagic = "";
        nextSpell = "";
        magicGameObject = GameObject.Find("MagicPrepped");
        anim = this.gameObject.GetComponentInChildren<Animator>();
        water = Resources.Load("Water", typeof(Sprite)) as Sprite;
        fire = Resources.Load("Fire", typeof(Sprite)) as Sprite;
        earth = Resources.Load("Earth", typeof(Sprite)) as Sprite;
        air = Resources.Load("Air", typeof(Sprite)) as Sprite;
        life = Resources.Load("Life", typeof(Sprite)) as Sprite;
        death = Resources.Load("Death", typeof(Sprite)) as Sprite;
        lightSprite = Resources.Load("Light", typeof(Sprite)) as Sprite;
        dark = Resources.Load("Dark", typeof(Sprite)) as Sprite;
        magicSpriteRenderer = magicGameObject.GetComponent<SpriteRenderer>();
	}

    public PlayerController KnockBack(bool fromRight)
    {
        if (immunityCount <= 0)
        {
            knockFromRight = fromRight;
            knockbackCount = knockbackLength;
            rb.velocity = new Vector2(0, 0);
        }
        return this;
    }

    public PlayerController HurtPlayer(int damage)
    {
        if (immunityCount <= 0)
        {
            immunityCount = immunityLength;
            health -= damage;
        }
        return this;
    }

    void castSpell ()
    {
        Camera camera = Camera.main;
        Vector3 mouseVector = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));

        Vector3 p = Vector3.Normalize(new Vector3(mouseVector.x - rb.position.x, mouseVector.y - rb.position.y));
        GameObject spell = null;
        if (nextSpell == "fire")
        {
            spell = (GameObject)Instantiate(firePrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 10;
            projectileCtrl.direction = p;
        }
        if (nextSpell == "water")
        {
            spell = (GameObject)Instantiate(waterPrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 8;
            projectileCtrl.direction = p;
        }
        if (nextSpell == "air")
        {
            spell = (GameObject)Instantiate(airPrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 15;
            projectileCtrl.direction = p;
        }
        if (nextSpell == "earth")
        {
            spell = (GameObject)Instantiate(earthPrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 6;
            projectileCtrl.direction = p;
        }
        if (nextSpell == "light")
        {
            spell = (GameObject)Instantiate(lightPrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 6;
            projectileCtrl.direction = p;
        }
        if (nextSpell == "dark")
        {
            spell = (GameObject)Instantiate(darkPrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 6;
            projectileCtrl.direction = p;
        }
        if (nextSpell == "life")
        {
            spell = (GameObject)Instantiate(lifePrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 6;
            projectileCtrl.direction = p;
        }
        if (nextSpell == "death")
        {
            spell = (GameObject)Instantiate(deathPrefab, transform.position, Quaternion.identity);
            Projectile projectileCtrl = spell.GetComponent<Projectile>();
            projectileCtrl.velocity = 6;
            projectileCtrl.direction = p;
        }
        if (spell != null) activeSpells.Add(spell);
    }
    // Update is called once per frame
    void Update ()
    {   
        if(health <= 0)
            SceneManager.LoadScene("GameOverScreen", LoadSceneMode.Single);
        // Is the player knocked back?
        if (knockbackCount <= 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (gameObject.transform.rotation.y == 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }

            if (Input.GetKey(KeyCode.A) && canMoveLeft)
            {
                if (!anim.GetBool("runningLeft")) {
                    anim.SetBool("runningRight", false);
                    anim.SetBool("runningLeft", true);
                }
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else if (Input.GetKey(KeyCode.A) && !canMoveLeft)
            {
                anim.SetBool("runningLeft", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("runningLeft", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if(gameObject.transform.rotation.y != 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (Input.GetKey(KeyCode.D) && canMoveRight)
            {
                if (!anim.GetBool("runningRight"))
                {
                    anim.SetBool("runningLeft", false);
                    anim.SetBool("runningRight", true);
                }
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else if (Input.GetKey(KeyCode.D) && !canMoveRight)
            {
                anim.SetBool("runningRight", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("runningRight", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.W) && (canJump || canDoubleJump))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                if (!canJump) canDoubleJump = false;
            }
        }
        else
        {
            /*if (knockFromRight)
            {
                rb.AddForce(new Vector2(-knockback / 2, knockback * 2.5f), ForceMode2D.Impulse);
            } else
            {
                rb.AddForce(new Vector2(knockback / 2, knockback * 2.5f), ForceMode2D.Impulse);
            }*/
            if (knockFromRight)
            {
                rb.velocity = new Vector2(-knockback * (knockbackCount / knockbackLength), (knockbackCount < knockbackLength / 2 ? -1 : 1) * (knockback / 2) * (knockbackCount / knockbackLength));
            }
            else
            {
                rb.velocity = new Vector2(knockback * (knockbackCount/knockbackLength), (knockbackCount < knockbackLength / 2 ? -1 : 1) * (knockback / 2) * (knockbackCount / knockbackLength));
            }
            knockbackCount -= Time.deltaTime;
        }

        if (immunityCount > 0) immunityCount -= Time.deltaTime;

        //DO MAGICS
        if (Input.GetMouseButtonDown(1) && currentMagic.Length > 0) {
            nextSpell = currentMagic;
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
            else if (nextSpell == "light")
                magicSpriteRenderer.sprite = lightSprite;
            else if (nextSpell == "dark")
                magicSpriteRenderer.sprite = dark;
        }
        if (Input.GetMouseButtonDown(0) && nextSpell.Length > 0)
        {
            castSpell();
            nextSpell = "";
            magicSpriteRenderer.sprite = null;
        }

        for (int i = 0; i < activeSpells.Count; i++)
        {
            GameObject spell = activeSpells[i];
            
            if (spell != null)
            {
                Projectile projectileController = spell.GetComponent<Projectile>();
                if (projectileController.removeMe)
                {
                    DestroyObject(spell);
                    activeSpells.Remove(spell);
                } else { 
                    spell.transform.Translate(projectileController.direction * Time.deltaTime * projectileController.velocity);
                }
            }
        }
    }
}
