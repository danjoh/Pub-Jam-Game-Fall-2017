using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticalDoorScript : MonoBehaviour {
    public int count;
    BoxCollider2D bc;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        count = 0;
        bc = this.GetComponent<BoxCollider2D>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (count > 2) {
            if (this.transform.position.y >= 200)
            {
                rb.velocity = new Vector2(0, 0);
                this.gameObject.SetActive(false);
            } else
            {
                bc.enabled = false;
                rb.velocity = new Vector2(0, 4.0f);
            }
        }
    }
}
