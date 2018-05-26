using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkcube2 : MonoBehaviour {
    private GameObject cube1;
    private Transform point1;

    public bool rightbool;
    public bool leftbool;
    public bool forwardbool;
    public bool backwardbool;
    private int raylength;
    private Vector3 back;
    private Vector3 forward;
    private Vector3 left;
    private Vector3 right;

    // Use this for initialization
    void Awake () //used awake which is called before update while start is called only if object is enabled
    {
        raylength = 1000;
        forward = transform.TransformDirection(Vector3.forward);
        back = transform.TransformDirection(Vector3.back);
        right = transform.TransformDirection(Vector3.right);
        left = transform.TransformDirection(Vector3.left);

    }
	
	// Update is called once per frame
	void Update () {
	    cube1 = GameObject.FindGameObjectWithTag("cube1");
	    if (cube1 != null)
	    {
	        point1 = GameObject.FindGameObjectWithTag("cube1").transform;
	        transform.position = new Vector3(point1.position.x, point1.position.y, point1.position.z);

	    }

    }

    void FixedUpdate()
    {
        if (gameObject.name == "right")
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, right * raylength);
            if (Physics.Raycast(transform.position, right, out hit, raylength))
            {
                //Debug.Log(hit.transform.name);
                if (cube1 != null && hit.transform.tag == "cube2")
                {
                    rightbool = true;
                }
                else
                {
                    rightbool = false;
                }
            }
        }
        else if (gameObject.name == "left")
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, left * raylength);
            if (Physics.Raycast(transform.position, left, out hit, raylength))
            {
                //Debug.Log(hit.transform.name);
                if (cube1 != null && hit.transform.tag == "cube2")
                {
                    leftbool = true;
                }
                else
                {
                    leftbool = false;
                }
            }
        }
        else if (gameObject.name == "forward")
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, forward * raylength);
            if (Physics.Raycast(transform.position, forward, out hit, raylength))
            {
                //Debug.Log(hit.transform.name);
                if (cube1 != null && hit.transform.tag == "cube2")
                {
                    forwardbool = true;
                }
                else
                {
                    forwardbool = false;
                }
            }
        }
        else if (gameObject.name == "backward")
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, back * raylength);
            if (Physics.Raycast(transform.position, back, out hit, raylength))
            {
                //Debug.Log(hit.transform.name);
                if (cube1 != null && hit.transform.tag == "cube2")
                {
                    backwardbool = true;
                }
                else
                {
                    backwardbool = false;
                }
            }
        }
    }
}
