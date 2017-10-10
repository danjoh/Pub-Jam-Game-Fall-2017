using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticalDoorScript : MonoBehaviour {
    public bool trigger1, trigger2, trigger3, trigger4;

	// Use this for initialization
	void Start () {
        trigger1 = false;
        trigger2 = false;
        trigger3 = false;
        trigger4 = false;
    }

    void CheckTriggers()
    {
        if(trigger1 == true && trigger2 == true && trigger3 == true && trigger4 == true)
        {
            if(this.transform.position.y >= 200)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5.0f);
            }
        }
    }
}
