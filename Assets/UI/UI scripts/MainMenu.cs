using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;

    public void PlayGame()
    {
        fader.FadeToIndex(PlayerPrefs.GetInt("levelReached",1));
        Debug.Log("Play button pressed");
    }

}
