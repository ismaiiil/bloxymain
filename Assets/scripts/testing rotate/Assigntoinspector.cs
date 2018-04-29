using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assigntoinspector : MonoBehaviour {
    public GameObject player;


    // Use this for initialization
    void Start () {
        

    }

    void OnTriggerStay(Collider other)
    {
        if (gameObject.name == "right") {
            if (other.tag == "playerpivot")
            {
                GameObject player = GameObject.Find("player");
                MoveCuboid Movescript = player.GetComponent<MoveCuboid>();
                Movescript.edgeR = other.gameObject;
            }
        }
        if (gameObject.name == "left")
        {
            if (other.tag == "playerpivot")
            {
                GameObject player = GameObject.Find("player");
                MoveCuboid Movescript = player.GetComponent<MoveCuboid>();
                Movescript.edgeL = other.gameObject;
            }
        }
        if (gameObject.name == "rear")
        {
            if (other.tag == "playerpivot")
            {
                GameObject player = GameObject.Find("player");
                MoveCuboid Movescript = player.GetComponent<MoveCuboid>();
                Movescript.edgeRE = other.gameObject;
            }
        }
        if (gameObject.name == "front")
        {
            if (other.tag == "playerpivot")
            {
                GameObject player = GameObject.Find("player");
                MoveCuboid Movescript = player.GetComponent<MoveCuboid>();
                Movescript.edgeFR = other.gameObject;
            }
        }


    }

    // Update is called once per frame
    void Update () {


    }
}
