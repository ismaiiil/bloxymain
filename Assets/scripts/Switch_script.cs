using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_script : MonoBehaviour {
    public bool switched_pressed;
    public float amount;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(((other.gameObject.tag == "cuboid_colliders")|| (other.gameObject.tag == "toporbot")) && switched_pressed == false)
        {
            switched_pressed = true;
            transform.Translate(Vector3.down * amount, Space.World);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update () {

		
	}
}
