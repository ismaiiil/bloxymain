﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public bool isTimerOn;
    public Text TimerText;
    public GameObject Timer;
    public float timeLeft;
    public SceneFader sceneFader;
    private GameObject UImemory;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
	    UImemory = GameObject.Find("UImemory");
	    UIScore score = UImemory.GetComponent<UIScore>();
        if ((Input.GetKeyDown(KeyCode.T) && !isTimerOn) && score.moves == 0)
	    {
	        isTimerOn = true;
            Timer.SetActive(true);
	    }

	    if (isTimerOn)
	    {
	        if (timeLeft > 0)
	        {
	            timeLeft -= Time.deltaTime;
	            TimerText.text = "Time Left: " + timeLeft.ToString("F2");
	        }
	        else
	        {
                sceneFader.FadeTo(SceneManager.GetActiveScene().name);
	            TimerText.text = "Times UP!";

            }

	    }

	}
}
