using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dead_respawn : MonoBehaviour {
	public GameObject player;
	public Animator cube_enter;
	public bool falls;
	// Use this for initialization
	void Start () {
		cube_enter = GetComponentInParent<Animator> ();
	}
	void OnCollisionEnter(Collision other){
		
		if ((other.gameObject.tag == "deadzone") && !falls) {
            //StartCoroutine(Delayrestart(1f));
            falls = true;
			
		
	}

	}
	void Update(){
		if ((cube_enter != null) && (cube_enter.GetBool("is_enter") == true)){
			falls = false;
		}
	}



}
	
	// Update is called once per frame

