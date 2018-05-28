using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGame()
    {
        fader.FadeToIndex(PlayerPrefs.GetInt("levelReached",1));
        Debug.Log("Play button pressed");
    }

}
