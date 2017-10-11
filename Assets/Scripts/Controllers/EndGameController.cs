using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if(collision.name == "Player")
        {
            SceneManager.LoadScene("GameWonScreen", LoadSceneMode.Single);
        }
    }
}
