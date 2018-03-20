using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class break_wood : MonoBehaviour
{
    public GameObject player;
    public GameObject wood;
    public GameObject woodcopy;


    public Vector3 originalposition;
    public Quaternion originalquaternion;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        originalposition = gameObject.transform.position;
        originalquaternion = gameObject.transform.rotation;

    }


    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "faceBo") || (other.gameObject.name == "faceT"))
        {
            
            makewoodfall();
            makeplayerfall();
            StartCoroutine(Delayrestart(1f));
            //StartCoroutine(Delayinstantiate(1.5f));
            //StartCoroutine(DelayDestroy(2f));



        }

    }


    IEnumerator Delayinstantiate(float time)
    {
        yield return new WaitForSeconds(time);
        woodcopy = Instantiate(wood, transform.position, Quaternion.identity);
        Debug.Log("wood prefab at position" + transform.position);

    }
    IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Debug.Log(gameObject + "destroyed");
    }
    IEnumerator Delayrestart(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }


        void makeplayerfall() {
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Collider>().isTrigger = false;
    }

    void makewoodfall() {
        for (int i = 0; i < 8; i++)
        {

            gameObject.GetComponentsInChildren<Rigidbody>()[i].useGravity = true;
            gameObject.GetComponentsInChildren<Rigidbody>()[i].isKinematic = false;
            gameObject.GetComponentsInChildren<Collider>()[i].isTrigger = false;
            

        }
        gameObject.GetComponent<Collider>().enabled = false;
    }

  
    void Update()
    {
       

    }
}