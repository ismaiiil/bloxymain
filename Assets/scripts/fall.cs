using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour {
	public GameObject player;
	public bool falls;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "tile_fall") {
			player.GetComponent<Rigidbody>().useGravity = true;
			player.GetComponent<Rigidbody>().isKinematic = false;
			falls = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
