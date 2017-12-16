using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_stopanim : MonoBehaviour {
	public Animator cube_enter;
	// Use this for initialization
	void Start () {
		cube_enter = GetComponentInParent<Animator> ();
		cube_enter.Play ("cube_enter");
	}

	IEnumerator delayresp(float time){
		yield return new WaitForSeconds(time);
		cube_enter.SetBool ("is_enter", true);
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "deadzone") {
			cube_enter.SetBool ("is_enter", true);
		}

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "tile_normal") {
			cube_enter.SetBool ("is_enter", false);
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
