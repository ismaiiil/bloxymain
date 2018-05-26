using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mergecubes : MonoBehaviour {
    public GameObject cube1;
    public GameObject cube2;
    public GameObject playerprefab;
    public GameObject player;
    public Vector3 median;
    public bool moving;

    public GameObject right;
    public GameObject left;
    public GameObject forward;
    public GameObject backward;

    public bool rightbool;
    public bool leftbool;
    public bool forwardbool;
    public bool backwardbool;

    // Use this for initialization
    void Start () {
        cube1 = GameObject.FindGameObjectWithTag("cube1");
        cube2 = GameObject.FindGameObjectWithTag("cube2");
    }
    void OnTriggerStay(Collider other)
    {
        if (!moving && (forwardbool || backwardbool))
        {
            median = cube1.transform.position + ((cube2.transform.position - cube1.transform.position) / 2);

            if (other.gameObject.tag == "cuboid_colliders")
            {
                Quaternion rot = Quaternion.Euler(90, 0, 0);
                player = Instantiate(playerprefab, median, rot);
                Destroy(cube1);
                Destroy(cube2);

            }
        }
        if (!moving && (rightbool || leftbool))
        {
            median = cube1.transform.position + ((cube2.transform.position - cube1.transform.position) / 2);

            if (other.gameObject.tag == "cuboid_colliders")
            {
                Quaternion rot = Quaternion.Euler(0, 0, 90);
                player = Instantiate(playerprefab, median, rot);
                Destroy(cube1);
                Destroy(cube2);

            }
        }



    }
    // Update is called once per frame
    void Update ()
    {

        right = GameObject.Find("right");
        left = GameObject.Find("left");
        forward = GameObject.Find("forward");
        backward = GameObject.Find("backward");

        checkcube2 checkright = right.GetComponent<checkcube2>();
        rightbool = checkright.rightbool;

        checkcube2 checkleft = left.GetComponent<checkcube2>();
        leftbool = checkleft.leftbool;

        checkcube2 checkforward = forward.GetComponent<checkcube2>();
        forwardbool = checkforward.forwardbool;

        checkcube2 checkback = backward.GetComponent<checkcube2>();
        backwardbool = checkback.backwardbool;


        if (transform.hasChanged)
        {
            moving = true;
            transform.hasChanged = false;
        }
        else
        {
            moving = false;
        }



    }
}
