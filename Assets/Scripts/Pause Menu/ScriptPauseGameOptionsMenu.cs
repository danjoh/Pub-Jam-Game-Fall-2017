using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script for the 'Game options' panel
public class ScriptPauseGameOptionsMenu : MonoBehaviour {
    public Transform gameOptionsPanel;
    public Transform optionsPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPressBack()
    {
        gameOptionsPanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(true);
    }
}
