using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movedatass : MonoBehaviour {

    public Transform rotator;
    public float speed = 3.0f;
    public float halfcube = 0.5f;
    public bool rotating = false;


    IEnumerator Rotatecuboid(Vector3 refpoint,Vector3 rotationAxis)
    {
        //transform.GetComponent<Renderer>().bounds.
        rotator.localRotation = Quaternion.identity;
        rotator.position = transform.position - Vector3.up * halfcube + refpoint;
        transform.parent = rotator;
        float angle= 0.0f;
        while (angle < 90.0f)
        {
            angle += Time.deltaTime * 90.0f * speed;
            rotator.rotation = Quaternion.AngleAxis(Mathf.Min(angle, 90.0f), rotationAxis);
            yield return null;

        }
        transform.parent = null;
        rotating = false;
    }
	// Use this for initialization
	void Start () {
        //halfcube = transform.lossyScale.x / 2;
        rotator = (new GameObject("Rotator")).transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (!rotating)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rotating = true;
                Debug.Log(gameObject.transform.localRotation.ToString());
                StartCoroutine(Rotatecuboid(new Vector3(1,0,0) * halfcube , -Vector3.forward));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log(gameObject.transform.localRotation.ToString());
                rotating = true;
                StartCoroutine(Rotatecuboid(-Vector3.right * halfcube, Vector3.forward));
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Debug.Log(gameObject.transform.localRotation.ToString());
                rotating = true;
                StartCoroutine(Rotatecuboid(Vector3.forward * halfcube, Vector3.right));
            }
            else if (Input.GetKey(KeyCode.S))
            {

                rotating = true;
                StartCoroutine(Rotatecuboid(-Vector3.forward * halfcube, -Vector3.right));
            }
        }
    }
}
