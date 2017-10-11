using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour {

    PlayerController pc;

    public GameObject spawnLoc;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (pc.GetComponent<Collider2D>().Equals(other)) {
            SceneManager.LoadScene("SceneNext", LoadSceneMode.Single);
        }
    }
}
