using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folllow : MonoBehaviour {
    Transform edge1;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        edge1 = GameObject.Find("edge1").transform; ;
        transform.position = new Vector3(edge1.position.x, edge1.position.y, edge1.position.z);
    }
}
