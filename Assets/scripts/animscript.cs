using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animscript : MonoBehaviour {
	static Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			anim.SetBool ("ishorizontal", true);
			anim.SetBool ("isvertical", false);
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			anim.SetBool ("isvertical", true);
			anim.SetBool ("ishorizontal", false);
		}
	}
}
