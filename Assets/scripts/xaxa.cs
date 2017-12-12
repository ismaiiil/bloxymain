using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xaxa : MonoBehaviour {
	GameObject child;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.W)) {
			child = GameObject.Find ("top");
			player.transform.RotateAround (child.transform.position, Vector3.left, -90);
		}
	}
}
