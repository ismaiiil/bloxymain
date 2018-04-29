using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class move_cuboid1 : MonoBehaviour {
			
	public bool shouldmove;
	public Animator cube_enter;
	public Rigidbody cube;
	public AnimationClip cube_anim;

	public int moves;
	public Text moves_text;

    public GameObject edgeR;
    public GameObject edgeL;
    public GameObject edgeFR;
    public GameObject edgeRE;

    public Transform rotator;
    public bool rotating;
    public int halfcube;
    public float speed;
    public GameObject ParentOf;



    void Start () {
        speed = 3.5f;
        cube_enter = GetComponentInParent<Animator> ();
		cube = GetComponent<Rigidbody> ();
		//scale = transform.lossyScale;
		moves = 0;
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

    void Update () {

		moves_text.text = "Moves: " + moves.ToString ();
		
		if (cube_enter.GetBool ("is_enter") == true) {
			shouldmove = false;			
		}
		else if(cube.useGravity == true){
			shouldmove = false;
		}
		else if(cube_enter.GetCurrentAnimatorStateInfo(0).IsName("cube_enter")){
			shouldmove = false;
		}else {
			shouldmove = true;
		}

        if (!rotating && shouldmove)
        {
            if (Input.GetKey(KeyCode.S))
            {
                moves++;
                rotating = true;
                //Debug.Log(gameObject.transform.localRotation.ToString());
                StartCoroutine(Rotatecuboid(edgeR, -Vector3.forward));
            }
            else if (Input.GetKey(KeyCode.W))
            {
                moves++;
                //Debug.Log(gameObject.transform.localRotation.ToString());
                rotating = true;
                StartCoroutine(Rotatecuboid(edgeL, Vector3.forward));
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moves++;
                //Debug.Log(gameObject.transform.localRotation.ToString());
                rotating = true;
                StartCoroutine(Rotatecuboid(edgeFR, Vector3.right));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                moves++;
                rotating = true;
                StartCoroutine(Rotatecuboid(edgeRE, -Vector3.right));
            }
        }

    }

}
