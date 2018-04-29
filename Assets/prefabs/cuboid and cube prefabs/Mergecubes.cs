using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mergecubes : MonoBehaviour {
    public GameObject cube1;
    public GameObject cube2;
    public GameObject playerprefab;
    public GameObject player;
    public Vector3 median;
    // Use this for initialization
    void Start () {
        cube1 = GameObject.FindGameObjectWithTag("cube1");
        cube2 = GameObject.FindGameObjectWithTag("cube2");
    }
    void OnTriggerStay(Collider other)
    {
        median = cube1.transform.position + ((cube2.transform.position - cube1.transform.position)/2);
        
        if (other.gameObject.tag == "cuboid_colliders") {
            Quaternion rot = Quaternion.Euler(90, 0, 0);
            player = Instantiate(playerprefab,median,rot);
            Destroy(cube1);
            Destroy(cube2);

        }
        
    }
    // Update is called once per frame
    void Update () {

	}
}
