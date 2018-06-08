using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cubefall : MonoBehaviour {
    Transform point1;
    public int raylength;
    public GameObject cube1;
    Transform point2;
    public GameObject cube2;
    // Use this for initialization
    void Start()
    {
        raylength = 100;
    }
    IEnumerator Delayrestart(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.name == "cube1ray") {
            cube1 = GameObject.FindGameObjectWithTag("cube1");
            if (cube1 != null)
            {
                point1 = GameObject.FindGameObjectWithTag("raytarget1").transform;
                transform.position = new Vector3(point1.position.x, point1.position.y, point1.position.z);

            }
        }
        if (gameObject.name == "cube2ray")
        {
            cube2 = GameObject.FindGameObjectWithTag("cube2");
            if (cube2 != null)
            {
                point2 = GameObject.FindGameObjectWithTag("raytarget2").transform;
                transform.position = new Vector3(point2.position.x, point2.position.y, point2.position.z);

            }
        }



        }
    void FixedUpdate()
    {
        if (gameObject.name == "cube1ray")
        {
            RaycastHit hit;
            Vector3 down = transform.TransformDirection(Vector3.down);
            Debug.DrawRay(transform.position, down * raylength);
            if (Physics.Raycast(transform.position, down, out hit, raylength))
            {
                //Debug.Log(hit.transform.name);
                if (cube1 != null && hit.transform.tag == "deadzone")
                {
                    cube1.GetComponent<Rigidbody>().useGravity = true;
                    cube1.GetComponent<Rigidbody>().isKinematic = false;
                    cube1.GetComponent<Collider>().isTrigger = false;
                    StartCoroutine(Delayrestart(1.0f));
                    cube1 = null;
                }
            }
        }
        if (gameObject.name == "cube2ray")
        {
            RaycastHit hit;
            Vector3 down = transform.TransformDirection(Vector3.down);
            Debug.DrawRay(transform.position, down * raylength);
            if (Physics.Raycast(transform.position, down, out hit, raylength))
            {
                //Debug.Log(hit.transform.name);
                if (cube2 != null && hit.transform.tag == "deadzone")
                {
                    cube2.GetComponent<Rigidbody>().useGravity = true;
                    cube2.GetComponent<Rigidbody>().isKinematic = false;
                    cube2.GetComponent<Collider>().isTrigger = false;
                    StartCoroutine(Delayrestart(1.0f));
                    cube2 = null;
                }
            }
        }
        }
}
