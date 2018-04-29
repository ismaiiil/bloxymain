using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCuboid : MonoBehaviour {
    public GameObject edgeR;
    public GameObject edgeL;
    public GameObject edgeFR;
    public GameObject edgeRE;

    public Transform rotator;
    public bool rotating;
    public int halfcube;
    public float speed;
    public GameObject ParentOf;


    // Use this for initialization
    void Start () {
        rotator = (new GameObject("Rotator")).transform;
    }

    IEnumerator Rotatecuboid(GameObject p, Vector3 axisanddir)
    {
        rotator.localRotation = Quaternion.identity;
        rotator.position = p.transform.position;
        rotator.parent = ParentOf.transform;

        transform.parent = rotator;
        float angle = 0.0f;
        while (angle < 90.0f)
        {
            angle += Time.deltaTime * 90.0f * speed;
            rotator.rotation = Quaternion.AngleAxis(Mathf.Min(angle, 90.0f), axisanddir);
            yield return null;

        }
        transform.parent = ParentOf.transform;
        rotating = false;
    }

    void Update() 
    {
        if (!rotating)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rotating = true;
                Debug.Log(gameObject.transform.localRotation.ToString());
                StartCoroutine(Rotatecuboid(edgeR, -Vector3.forward));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log(gameObject.transform.localRotation.ToString());
                rotating = true;
                StartCoroutine(Rotatecuboid(edgeL, Vector3.forward));
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Debug.Log(gameObject.transform.localRotation.ToString());
                rotating = true;
                StartCoroutine(Rotatecuboid(edgeFR, Vector3.right));
            }
            else if (Input.GetKey(KeyCode.S))
            {

                rotating = true;
                StartCoroutine(Rotatecuboid(edgeRE, -Vector3.right));
            }
        }
        //transform.RotateAround(edge.transform.position,-Vector3.forward,Time.deltaTime*90);
    }


}
