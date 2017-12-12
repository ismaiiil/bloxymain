using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecuboid2 : MonoBehaviour {
	public Rigidbody rb;
	public float amount = 50f;
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			rb.AddTorque(transform.forward * amount);
		}
		if (Input.GetKeyDown (KeyCode.D) ){
			rb.AddTorque(transform.forward * -amount);
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			rb.AddTorque(transform.right * amount);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			rb.AddTorque(transform.right * -amount);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
