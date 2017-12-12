using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testanim : MonoBehaviour {

	public GameObject tile;
	static Animator pressed;
	// Use this for initialization
	void Start () {
		pressed = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			pressed.SetBool ("pressed", true);
		}
	}
}
