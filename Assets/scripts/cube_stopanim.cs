using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_stopanim : MonoBehaviour {
	public Animator cube_enter;
	// Use this for initialization
	void Start () {
		cube_enter = GetComponentInParent<Animator> ();
        if (cube_enter != null) {
            cube_enter.Play("cube_enter");
        }
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "tile_normal") {
            if (cube_enter != null)
            { cube_enter.SetBool("is_enter", false);
            }
                
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
