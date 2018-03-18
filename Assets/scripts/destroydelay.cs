using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroydelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    IEnumerator DelayDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Debug.Log(gameObject + "destroyed");
    }
    // Update is called once per frame
    void Update () {
        if (gameObject.GetComponent<Rigidbody>().useGravity == true) {
            StartCoroutine(DelayDestroy(1.5f));
        }
		
	}
}
