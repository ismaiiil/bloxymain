using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerfall : MonoBehaviour
{
    Transform bar;
    public int raylength;
    public GameObject player;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            if (gameObject.name == "bar_top")
            {
                bar = GameObject.Find("toptarget").transform;
                transform.position = new Vector3(bar.position.x, bar.position.y, bar.position.z);
            }
            if (gameObject.name == "bar_bot")
            {
                bar = GameObject.Find("bottarget").transform;
                transform.position = new Vector3(bar.position.x, bar.position.y, bar.position.z);
            }
        }
        

    }
    void FixedUpdate()
    {

        RaycastHit hit;
        Vector3 down = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(transform.position, down * raylength);
        if (Physics.Raycast(transform.position,down, out hit, raylength))
        {
            //Debug.Log(hit.transform.name);
            if (player != null && hit.transform.tag == "deadzone")
            {
                player.GetComponent<Rigidbody>().useGravity = true;
                player.GetComponent<Rigidbody>().isKinematic = false;
                player.GetComponent<Collider>().isTrigger = false;
                StartCoroutine(Delayrestart(1.0f));
            }
        }
    }
    IEnumerator Delayrestart(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
}
