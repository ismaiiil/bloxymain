using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public bool isTimerOn;
    public Text TimerText;
    public GameObject Timer;
    public float timeLeft;
    public SceneFader sceneFader;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.T) && !isTimerOn)
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
	            TimerText.text = "Times UP!";

            }

	    }

	}
}
