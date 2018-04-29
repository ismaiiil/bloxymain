using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceBot : MonoBehaviour {
	public bool faceBo;
	public GameObject player;
	private Collider faceBottom;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other){

		faceBo = true;


	}

	void OnTriggerExit(Collider other){

		faceBo = false;
	}
}
