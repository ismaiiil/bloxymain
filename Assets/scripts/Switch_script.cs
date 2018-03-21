using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_script : MonoBehaviour {
    public bool switched_pressed;
    public float amount;
    public GameObject closebridges;
    public GameObject counterswitches;

     
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if((((other.gameObject.tag == "cuboid_colliders") &&(gameObject.tag == "round_switch"))|| (other.gameObject.tag == "toporbot")) && switched_pressed == false)
        {
            switched_pressed = true;
            transform.Translate(Vector3.down * amount, Space.World);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            CloseBridges();



        }
    }

    void CloseBridges() {
        Animator[] animators = closebridges.GetComponentsInChildren<Animator>();
        foreach (Animator animator in animators)
        {
            animator.SetBool("switch_closed", true);
        }
    }
    // Update is called once per frame
    void Update () {

		
	}
}
