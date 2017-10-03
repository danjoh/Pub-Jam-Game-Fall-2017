using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script for the options menu accessible from the pause menu
// A different script handles the main menu options
public class ScriptPauseOptionsMenu : MonoBehaviour {
    public Transform optionsPanel;
    public Transform gameOptionsPanel;
    public Transform videoOptionsPanel;
    public Transform audioOptionsPanel;
    public Transform mainPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPressAudioSettings()
    {
        optionsPanel.gameObject.SetActive(false);
        audioOptionsPanel.gameObject.SetActive(true);
    }

    public void OnPressVideoSettings()
    {
        optionsPanel.gameObject.SetActive(false);
        videoOptionsPanel.gameObject.SetActive(true);
    }

    public void OnPressGameSettings()
    {
        optionsPanel.gameObject.SetActive(false);
        gameOptionsPanel.gameObject.SetActive(true);
    }

    public void OnPressBack()
    {
        optionsPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
    }
}
