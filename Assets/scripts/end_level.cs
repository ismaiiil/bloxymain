using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_level : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "tile_end") {
			player.GetComponent<Rigidbody>().useGravity = true;
			player.GetComponent<Rigidbody>().isKinematic = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
