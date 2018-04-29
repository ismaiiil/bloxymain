using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planefollow : MonoBehaviour {
    public GameObject player;
    private Transform playerpos;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("player");
        playerpos = player.transform; ;
        transform.position = new Vector3(playerpos.position.x, transform.position.y, playerpos.position.z);
    }
}
