using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possible : MonoBehaviour {
	public GameObject player;
	public GameObject centre;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 //whenever original player moves then update centerObject's position

 		centre.transform.position = player.transform.position;
         GameObject child;
         if (Input.GetKeyDown(KeyCode.UpArrow)){
             child = GameObject.Find("front");
             centre.transform.RotateAround(child.transform.position, Vector3.left, -90);
         }
         if (Input.GetKeyDown(KeyCode.DownArrow)){
             child = GameObject.Find("rear");
             centre.transform.RotateAround(child.transform.position, Vector3.left, 90);
         }
         if (Input.GetKeyDown(KeyCode.LeftArrow)){
             child = GameObject.Find("left");
             centre.transform.RotateAround(child.transform.position, Vector3.forward, 90);
         }
         if (Input.GetKeyDown(KeyCode.RightArrow)){
             child = GameObject.Find("right");
             centre.transform.RotateAround(child.transform.position, Vector3.forward, -90);
         }
	}
}
