using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_level : MonoBehaviour {
	public GameObject player;
	public bool nextlevel;
	// Use this for initialization
	void Start () {
		
	}
    //IEnumerator delaynextlevel (float time){
    //	yield return new WaitForSeconds (time);
    //	if (SceneManager.GetActiveScene().name == "level1") {
    //		SceneManager.LoadScene ("level2");
    //	}
    //}
    IEnumerator Delayrestart(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
    void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "tile_end") {
			player.GetComponent<Rigidbody>().useGravity = true;
			player.GetComponent<Rigidbody>().isKinematic = false;
			player.GetComponent<Collider> ().isTrigger = false;
            StartCoroutine(Delayrestart(1f));
            //nextlevel = true;
            //StartCoroutine ((delaynextlevel (1.5f)));

        }
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
