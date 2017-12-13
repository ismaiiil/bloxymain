using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_stopanim : MonoBehaviour {
	public Animator cube_enter;
	// Use this for initialization
	void Start () {
		cube_enter = GetComponentInParent<Animator> ();
	}

	IEnumerator ExecuteAfterTime(float time){
		yield return new WaitForSeconds(time);
		cube_enter.enabled = false;
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "tile_normal") {
			StartCoroutine (ExecuteAfterTime (2));
		}
		if (other.gameObject.tag == "deadzone") {
			cube_enter.enabled = true;
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
