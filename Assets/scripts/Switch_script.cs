﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_script : MonoBehaviour
{
    public bool switched_pressed;
    public bool change_position;
    public float amount;
    public GameObject[] closebridges;
    public GameObject[] openbridges;
    public GameObject counterswitches;
    public Color initial_color;
    public bool Counterswitch_pressed;


    // Use this for initialization
    void Start()
    {
        initial_color = gameObject.GetComponent<Renderer>().material.color;
        if (switched_pressed) {
            Bridgeoperator();
        }

    }

    void OnTriggerEnter(Collider other)
    {


        if ((((other.gameObject.tag == "cuboid_colliders") && (gameObject.tag == "round_switch")) ||
            (other.gameObject.tag == "toporbot")) && switched_pressed == false)
        {
            Bridgeoperator();


        }

    }

    void Bridgeoperator(){
        CloseBridges();
        OpenBridges();
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (change_position == false)
        {
            transform.Translate(Vector3.down * amount, Space.World);
            change_position = true;
        }
        switched_pressed = true;
        if (counterswitches != null)
        {
            counterswitches.GetComponent<Switch_script>().switched_pressed = false;
        }
    }

    void CloseBridges()
    {
        if ((closebridges.Length > 0) && (closebridges[0] != null ))
        {
            foreach (GameObject bridge in closebridges)
            {

                Animator[] animators = bridge.GetComponentsInChildren<Animator>();

                foreach (Animator animator in animators)
                {
                    animator.SetBool("switch_closed", true);
                    animator.SetBool("switch_opened", false);
                }
            }
        }
        else {
            Debug.Log("No bridge to be closed attached to this switch" + gameObject);
        }
        
    }

    void OpenBridges()
    {
        if ((openbridges.Length > 0) && (openbridges[0] != null))
        {
            foreach (GameObject bridge in openbridges)
            {
                Animator[] animators = bridge.GetComponentsInChildren<Animator>();

                foreach (Animator animator in animators)
                {
                    animator.SetBool("switch_closed", false);
                    animator.SetBool("switch_opened", true);
                }
            }
        }
        else
        {
            Debug.Log("No bridge to be opened attached to this switch" + gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (switched_pressed == false)
            {
            gameObject.GetComponent<Renderer>().material.color = initial_color;
            if (change_position == true)
            {
                transform.Translate(Vector3.up * amount, Space.World);
                change_position = false;
            }
            //OpenBridges();
            //Debug.Log("since false i open bridge");
            }


        }
    }
