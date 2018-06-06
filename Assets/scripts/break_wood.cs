using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class break_wood : MonoBehaviour
{
    public GameObject player;
    public GameObject wood;
    public GameObject woodcopy;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }


    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "toporbot"))
        {
            
            makewoodfall();
            makeplayerfall();
            StartCoroutine(Delayrestart(1f));



        }

    }

    IEnumerator Delayrestart(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }


    void makeplayerfall()
    {
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Collider>().isTrigger = true;
    }

    void makewoodfall() {
        for (int i = 0; i < 8; i++)
        {

            gameObject.GetComponentsInChildren<Rigidbody>()[i].useGravity = true;
            gameObject.GetComponentsInChildren<Rigidbody>()[i].isKinematic = false;
            gameObject.GetComponentsInChildren<Collider>()[i].isTrigger = false;
            gameObject.GetComponentsInChildren<Rigidbody>()[i].AddForce(new Vector3(0,40,0), ForceMode.Impulse);

        }
        gameObject.GetComponent<Collider>().enabled = false;
    }
}