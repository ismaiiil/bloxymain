using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead_respawn : MonoBehaviour {
	public GameObject player;
	public Animator cube_enter;
	public bool falls;
	// Use this for initialization
	void Start () {
		cube_enter = GetComponentInParent<Animator> ();
	}
	void OnCollisionEnter(Collision other){
		
		if ((other.gameObject.tag == "deadzone") && !falls) {
			StartCoroutine ((Delayresp (1.0f)));
			falls = true;
			
		
	}

	}
	void Update(){
		if (cube_enter.GetBool("is_enter") == true){
			falls = false;
		}
	}
	IEnumerator Delayresp (float time)
	{
		yield return new WaitForSeconds (time);
		player.GetComponent<Rigidbody> ().useGravity = false;
		player.GetComponent<Rigidbody> ().isKinematic = true;
		player.transform.position = new Vector3 (0.495f, -0.165f, -2.993f);
		player.transform.localEulerAngles = new Vector3 (0, 0, 0);
		player.GetComponent<Collider> ().isTrigger = true;
		cube_enter.SetBool ("is_enter", true);
		//Debug.Log ("cube enter true");


	}
}
	
	// Update is called once per frame

