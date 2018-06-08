using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile_pressed : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		if ((other.gameObject.tag == "cuboid_colliders")||(other.gameObject.tag == "toporbot")) {
			anim.SetBool ("ispressed", true);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if ((other.gameObject.tag == "cuboid_colliders") || (other.gameObject.tag == "toporbot"))
        {
			anim.SetBool ("ispressed", false);
		}



	}
}
