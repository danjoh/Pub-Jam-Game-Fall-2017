using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// The script for the pause menu that shows up when the player presses the 'Escape' key
public class ScriptPauseMenu : MonoBehaviour {
    public Transform canvas;
    public Transform mainPanel;
    public Transform optionsPanel;
    // TODO: Add reference to the player controller to pause it
    public Transform player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Resume the game, same functionality as pressing escape again
    public void OnPressResume()
    {
        canvas.gameObject.SetActive(false);
        // Time scale of the scene is unfrozen
        Time.timeScale = 1;
        // Player controller is enabled
        // player.GetComponent<GameObject>().enabled = true;
    }

    // Brings up the options menu
    public void OnPressOptions()
    {
        mainPanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(true);
    }

    // Closes the scene and returns to the title scene
    public void OnPressQuitToTitle()
    {
        SceneManager.LoadScene("SceneMainMenu", LoadSceneMode.Single);
    }
}
