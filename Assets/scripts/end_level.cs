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

    // Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other){
        UImemory = GameObject.Find("UImemory");
        UIScore score = UImemory.GetComponent<UIScore>();
        if (other.gameObject.tag == "toporbot") {
			player.GetComponent<Rigidbody>().useGravity = true;
			player.GetComponent<Rigidbody>().isKinematic = false;
			player.GetComponent<Collider> ().isTrigger = false;
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

            sceneFader.FadeTo(nextlevel);
		    this.gameObject.GetComponent<Collider>().enabled = false;
     
            Debug.Log("change level to " + nextlevel );

		}
	}


	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
}
