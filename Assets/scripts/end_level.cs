using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_level : MonoBehaviour {
	public GameObject player;
	public string nextlevel;
    public int levelToUnlock;
    public SceneFader sceneFader;
    public GameObject UImemory;
    public GameObject Timer;
    public Light lt;
    public bool fade;

    // Use this for initialization
	void Start ()
	{
	    sceneFader = GameObject.Find("SceneFader").GetComponent<SceneFader>();
	    lt = GameObject.Find("end_light").GetComponent<Light>();

	}

    void OnTriggerEnter(Collider other){
        Timer = GameObject.Find("Timer");
        UImemory = GameObject.Find("UImemory");
        UIScore score = UImemory.GetComponent<UIScore>();
        if (other.gameObject.tag == "toporbot") {
			player.GetComponent<Rigidbody>().useGravity = true;
			player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<Rigidbody>().drag = 10;
            player.GetComponent<Collider> ().isTrigger = false;
            fade = true;

		    if (PlayerPrefs.GetInt("levelReached",1) < levelToUnlock)
		    {
		        PlayerPrefs.SetInt("levelReached", levelToUnlock);
            }

            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name,0) > score.moves 
                || PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) == 0)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, score.moves);
                Debug.Log("score" + score.moves);
            }

            if (Timer != null && Timer.activeSelf)
            {
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name+"score","Yes");
            }


            sceneFader.FadeTo(nextlevel);
		    this.gameObject.GetComponent<Collider>().enabled = false;
     
            Debug.Log("change level to " + nextlevel );

		}
	}


	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
	    if (fade)
	    {
	        lt.intensity += 10.0f;
        }
	}
}
