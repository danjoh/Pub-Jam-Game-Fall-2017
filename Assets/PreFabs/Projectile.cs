﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float velocity;
    public Vector3 direction;
    public bool removeMe;
    PlayerController pc;
    Collider2D gc;
    void Start ()
    {
        removeMe = false;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gc = GameObject.Find("GroundCheck").GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!pc.GetComponent<Collider2D>().Equals(other) && !gc.Equals(other.GetComponentInParent<Collider2D>()))
        {
            removeMe = true;
        }

    }
}