using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script for the 'Video options' panel
public class ScriptPauseVideoMenu : MonoBehaviour {
    public Transform videoOptionsPanel;
    public Transform optionsPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPressBack()
    {
        videoOptionsPanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(true);
    }
}
