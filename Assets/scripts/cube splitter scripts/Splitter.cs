using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour {

    public GameObject cube1prefab;
    public GameObject cube1;
    public GameObject cube2prefab;
    public GameObject cube2;
    public GameObject cube1destinationtile;
    public GameObject cube2destinationtile;
    public float above;
    //public bool ispressed;


	// Use this for initialization
	void Start () {
        above = 0.19f;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "toporbot") {
            Destroy(GameObject.FindGameObjectWithTag("Player"),0.5f);
            cube1 = Instantiate(cube1prefab, cube1destinationtile.transform.position + new Vector3(0,above), Quaternion.identity);
            cube2 = Instantiate(cube2prefab, cube2destinationtile.transform.position + new Vector3(0, above), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
