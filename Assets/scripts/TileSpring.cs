using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpring : MonoBehaviour
{
    private Vector3 pos;
	// Use this for initialization
	void Start ()
	{

	    pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    transform.rotation = Quaternion.Lerp(gameObject.transform.rotation,Quaternion.identity, Time.time * Time.deltaTime/4);
	    //transform.position = pos;
	}
}
