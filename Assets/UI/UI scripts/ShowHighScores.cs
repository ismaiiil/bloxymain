using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHighScores : MonoBehaviour
{
    public TextMeshProUGUI[] text;
	// Use this for initialization
	void Start () {
	    for (int i = 0; i < text.Length; i++)
	    {
	        if (PlayerPrefs.GetInt("level" + (i + 1), 0) == 0)
	        {
	            text[i].text = "Level " + (i + 1) + " : " + "--" + " moves";
            }
	        else
	        {
	            text[i].text = "Level " + (i + 1) + " : " + PlayerPrefs.GetInt("level" + (i + 1), 0) + " moves";
            }

	        
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
