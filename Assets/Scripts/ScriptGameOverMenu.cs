using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptGameOverMenu : MonoBehaviour {
    public void OnPressRestart()
    {
        SceneManager.LoadScene("SceneNext", LoadSceneMode.Single);
    }

    public void OnPressQuitButton()
    {
        SceneManager.LoadScene("SceneMainMenu", LoadSceneMode.Single);
    }
}
