using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCheck : MonoBehaviour {
    PlayerController pm;

    // Use this for initialization
    void Start()
    {
        pm = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D()
    {
        pm.canMoveRight = false;
    }

    private void OnTriggerExit2D()
    {
        pm.canMoveRight = true;
    }
}