using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool paused;
    public GameObject PauseGameObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) && !paused)
	    {
            PauseGameObject.SetActive(true);
	        paused = true;
	        StopTime();

	    }
	    else if (Input.GetKeyDown(KeyCode.Escape) && paused)
	    {
	        PauseGameObject.SetActive(false);
	        paused = false;
	        ResumeTime();
	    }

	}

    public void SetBoolPausedFalse()
    {
        paused = false;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }
    public void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
