using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Loads the next game scene
    public void OnPressStartButton()
    {
        SceneManager.LoadScene("Scene Next", LoadSceneMode.Additive);
    }

    // Quits the application
    public void OnPressQuitButton()
    {
        Application.Quit();
    }
}
