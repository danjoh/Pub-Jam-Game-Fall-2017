﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    PlayerController pc;

    public GameObject spawnLoc;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D()
    {
        pc.rb.position = spawnLoc.transform.position;
        Debug.Log("DO STUFF!!!!");
    }
}
