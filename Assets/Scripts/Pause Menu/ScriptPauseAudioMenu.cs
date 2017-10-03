using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script for the 'Audio options' panel
public class ScriptPauseAudioMenu : MonoBehaviour {
    public Transform audioOptionsPanel;
    public Transform optionsPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPressBack()
    {
        audioOptionsPanel.gameObject.SetActive(false);
        optionsPanel.gameObject.SetActive(true);
    }
}
