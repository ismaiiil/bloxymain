﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_respawn : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "deadzone") {
			player.GetComponent<Rigidbody>().useGravity = false;
			player.GetComponent<Rigidbody>().isKinematic = true;
			player.transform.position = new Vector3 (0.495f,-0.165f, -2.993f);
			player.transform.localEulerAngles = new Vector3 (0, 0, 0);
		
	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
