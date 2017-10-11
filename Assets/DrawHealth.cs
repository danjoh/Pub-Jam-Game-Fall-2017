using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHealth : MonoBehaviour {
    public int minHealth;
    PlayerController pc;
	// Use this for initialization
	void Start () {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pc.health >= minHealth)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
	}
}
