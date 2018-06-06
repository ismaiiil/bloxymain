using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public enum Direction
{
    North,
    South,
    East,
    West
}
public class MovecuboidV3 : MonoBehaviour
{

    public bool shouldmove;
    public Animator cube_animator;
    public Rigidbody cube;

    public int moves;
    public Text moves_text;
    public float rotationSpeed = 400;

    public bool ismoving;
    private Direction rotationDirection;
    private Vector3 pivot;
    private float finalRotation;
    private Vector3 axis;
    private Vector3 scale;

    public bool is_controlled;
    public Color initialcolor;
    public Quaternion initial;

    private GameObject UImemory;

    void Awake()
    {
        initialcolor = gameObject.GetComponent<Renderer>().material.color;

        if (gameObject.tag == "Player") {
            is_controlled = true;
        }
        if (gameObject.tag == "cube1") {
            StartCoroutine(Delaycontrol(0.6f));
        }
        if (gameObject.tag == "cube2")
        {
            is_controlled = false;
        }

        cube_animator = GetComponentInParent<Animator>();
        cube = GetComponent<Rigidbody>();
        ismoving = false;
        scale = transform.localScale / 2.0f;
        UImemory = GameObject.Find("UImemory");
        UIScore score = UImemory.GetComponent<UIScore>();
        moves = score.moves;
        moves_text = GameObject.Find("MovesText").GetComponent<Text>();
        initial = gameObject.transform.rotation;

    }
    IEnumerator Delaycontrol(float time) {
        yield return new WaitForSeconds(time);
        is_controlled = true;
    }

    void Update()
    {
        if ((gameObject.tag == "cube1" || gameObject.tag == "cube2") && Input.GetKeyDown(KeyCode.Tab))
        {
            is_controlled = !is_controlled;
        }
        

        if((cube_animator != null) && (cube_animator.GetBool("is_enter") == true))
        {
            shouldmove = false;
        }
        else if (cube.useGravity == true)
        {
            shouldmove = false;
        }
        else if ((cube_animator != null) && cube_animator.GetCurrentAnimatorStateInfo(0).IsName("cube_enter") )
        {
            shouldmove = false;
        }
        else
        {
            shouldmove = true;
        }
        if (Time.timeScale == 0)
        {
            shouldmove = false;
        }
        if (ismoving)
        {
            float deltaRotation = rotationSpeed * Time.deltaTime;
            if (finalRotation + deltaRotation >= 90)
            {
                deltaRotation = 90 - finalRotation;
                ismoving = false;
            }
            if ((rotationDirection == Direction.West) || (rotationDirection == Direction.North))
                transform.RotateAround(pivot, axis, deltaRotation);
            else transform.RotateAround(pivot, axis, -deltaRotation);

            finalRotation += deltaRotation;
        }
        else if (Input.GetKey(KeyCode.D) && shouldmove && is_controlled) Rotate(Direction.North);
        else if (Input.GetKey(KeyCode.W) && shouldmove && is_controlled) Rotate(Direction.West);
        else if (Input.GetKey(KeyCode.A) && shouldmove && is_controlled) Rotate(Direction.South);
        else if (Input.GetKey(KeyCode.S) && shouldmove && is_controlled) Rotate(Direction.East);

        if (is_controlled)
        {
            gameObject.GetComponent<Renderer>().material.color = initialcolor;
        }
        else {
            gameObject.GetComponent<Renderer>().material.color = initialcolor - new Color(0.8f,0.8f,0.8f);
        }

    }

    void Rotate(Direction direction)
    {
        UImemory = GameObject.Find("UImemory");
        UIScore score = UImemory.GetComponent<UIScore>();
        moves = score.moves;
        rotationDirection = direction;
        ismoving = true;
        finalRotation = 0;
        moves++;
        score.moves = moves;
        moves_text.text = "Moves: " + moves.ToString();
        //if (initial == Quaternion.identity)
        //{
        switch (rotationDirection)
            {
                case Direction.East:
                if (initial == Quaternion.identity)
                {
                    pivot = transform.position + new Vector3(scale.x, -scale.y, 0);
                    break;
                }
                else {
                    pivot = transform.position + new Vector3(scale.x, -scale.x, 0);
                    break;
                }
                case Direction.West:
                if (initial == Quaternion.identity)
                {
                    pivot = transform.position + new Vector3(-scale.x, -scale.y, 0);
                    break;
                }
                else {
                    pivot = transform.position + new Vector3(-scale.x, -scale.x, 0);
                    break;
                }
                case Direction.North:
                if (initial == Quaternion.identity) {
                    pivot = transform.position + new Vector3(0, -scale.y, scale.z);
                    break;
                }
                else {
                    pivot = transform.position + new Vector3(0, -scale.z, scale.y);
                    break;
                }
                
                //reversing y with z solves the original rotation problem
                case Direction.South:
                if (initial == Quaternion.identity)
                {
                    pivot = transform.position + new Vector3(0, -scale.y, -scale.z);
                    break;
                }
                else {
                    pivot = transform.position + new Vector3(0, -scale.z, -scale.y);
                    break;
                }
            }
            if ((rotationDirection == Direction.East) || (rotationDirection == Direction.West)  )
            {
                if (initial == Quaternion.identity)
                {
                    axis = Vector3.forward;
                    float temp = scale.x;
                    scale.x = scale.y;
                    scale.y = temp;
                }
            else
            {
                axis = Vector3.forward;
                float temp = scale.x;
                scale.y = scale.y;
                scale.x = temp;
            }


        }
            else /*if rot dir north or south*/
            {
                if (initial == Quaternion.identity)
                {
                    axis = Vector3.right;
                    float temp = scale.z;
                    scale.z = scale.y;
                    scale.y = temp;
                }
                else
                {
                    axis = Vector3.right;
                    float temp = scale.y;
                    scale.y = scale.z;
                    scale.z = temp;
                }

            }

        
        
        

        
    }
}

