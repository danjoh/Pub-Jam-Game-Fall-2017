using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    PlayerController pm;

	// Use this for initialization
	void Start () {
        pm = GetComponentInParent<PlayerController>();
	}

    void OnTriggerEnter2D () {
        pm.canJump = true;
        pm.canDoubleJump = true;
	}

    private void OnTriggerExit2D()
    {
        pm.canJump = false;
    }
}
