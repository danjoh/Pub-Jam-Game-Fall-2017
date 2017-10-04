using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCheck : MonoBehaviour {
    PlayerController pm;

    // Use this for initialization
    void Start () {
        pm = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(){
        pm.canMoveLeft = false;
    }

    private void OnTriggerExit2D(){
        pm.canMoveLeft = true;
    }
}
