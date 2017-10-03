using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Transform canvas;
    // TODO: Add reference to the player controller to pause it
    public Transform player;
    public GameObject pauseMenuPanel;
    private GameObject[] panels;

	// Use this for initialization
	void Start () {
        // Find objects at the start of runtime to make the game run smoother
        panels = GameObject.FindGameObjectsWithTag("Panel");
	}
	
	// Update is called once per frame
	void Update () {
        // Escape pauses the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    // Pause or resume the game
    public void Pause()
    {
        // If the canvas is inactive in hierarchy, set it active
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            // Enable the main panel if disabled
            if(pauseMenuPanel.gameObject.activeInHierarchy == false)
            {
                pauseMenuPanel.gameObject.SetActive(true);
            }
            // Time scale of the scene is frozen
            Time.timeScale = 0;
            // Player controller is disabled
            // player.GetComponent<appropriate type>().enabled = false;
        }
        else
        {
            // Disable any active panels
            // This has to be done before the parent canvas is disabled
            foreach (GameObject panel in panels)
            {
                if (panel.gameObject.activeInHierarchy == true)
                {
                    panel.gameObject.SetActive(false);
                }
            }
            canvas.gameObject.SetActive(false);
            // Time scale of the scene is unfrozen
            Time.timeScale = 1;
            // Player controller is enabled
            // player.GetComponent<appropriate type>().enabled = true;
        }
    }
}
