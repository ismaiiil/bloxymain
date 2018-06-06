using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class move_cuboid : MonoBehaviour {

	public float rotationPeriod = 0.3f;		
	Vector3 scale;							

	bool isRotate = false;
	public bool shouldmove;
	float directionX = 0;				
	float directionZ = 0;	

	float startAngleRad = 0;				
	Vector3 startPos;				
	float rotationTime = 0;			
	float radius = 1;					
	Quaternion fromRotation;			
	Quaternion toRotation;		

	public Animator cube_enter;
	public Rigidbody cube;
	public AnimationClip cube_anim;

	public int moves;
	public Text moves_text;
    private GameObject UImemory;


    void Start () {

		cube_enter = GetComponentInParent<Animator> ();
		cube = GetComponent<Rigidbody> ();
		scale = transform.lossyScale;
	    UImemory = GameObject.Find("UImemory");
	    UIScore score = UImemory.GetComponent<UIScore>();
	    moves = score.moves;
        moves_text = GameObject.Find("MovesText").GetComponent<Text>();


    }


	void Update () {

		moves_text.text = "Moves: " + moves.ToString ();
		
        if(cube.useGravity == true){
			shouldmove = false;
		}else {
			shouldmove = true;
		}

	    if (Time.timeScale == 0)
	    {
	        shouldmove = false;
	    }

	    float x = 0;
		float y = 0;

		if (shouldmove){
			x = Input.GetAxisRaw ("Horizontal");
			if (x == 0) {
				y = Input.GetAxisRaw ("Vertical");
			}
		}



		if ((x != 0 || y != 0) && !isRotate) {
			directionX = y;																
			directionZ = x;																
			startPos = transform.position;											
			fromRotation = transform.rotation;										
			transform.Rotate (directionZ * 90, 0, directionX * 90, Space.World);		
			toRotation = transform.rotation;											
			transform.rotation = fromRotation;										
			setRadius();															
			rotationTime = 0;															
			isRotate = true;
		    UImemory = GameObject.Find("UImemory");
		    UIScore score = UImemory.GetComponent<UIScore>();
		    moves = score.moves;
            moves++;

		    score.moves = moves;
		}
	}

	void FixedUpdate() {

		if ((isRotate)) {

			rotationTime += Time.fixedDeltaTime;								
			float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);			


			float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);					
			float distanceX = -directionX * radius * (Mathf.Cos (startAngleRad) - Mathf.Cos (startAngleRad + thetaRad));		
			float distanceY = radius * (Mathf.Sin(startAngleRad + thetaRad) - Mathf.Sin (startAngleRad));					
			float distanceZ = directionZ * radius * (Mathf.Cos (startAngleRad) - Mathf.Cos (startAngleRad + thetaRad));			
			transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);		


			transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);		


			if (ratio == 1) {
				isRotate = false;
				directionX = 0;
				directionZ = 0;
				rotationTime = 0;
			}
		}
	}

	void setRadius() {

		Vector3 dirVec = new Vector3(0, 0, 0);		
		Vector3 nomVec = Vector3.up;				


		if (directionX != 0) {						
			dirVec = Vector3.right;						
		} else if (directionZ != 0) {					
			dirVec = Vector3.forward;					
		} 


		if (Mathf.Abs (Vector3.Dot (transform.right, dirVec)) > 0.99) {						
			if (Mathf.Abs (Vector3.Dot (transform.up, nomVec)) > 0.99) {					
				radius = Mathf.Sqrt(Mathf.Pow(scale.x/2f,2f) + Mathf.Pow(scale.y/2f,2f));	
				startAngleRad = Mathf.Atan2(scale.y, scale.x);								
			} else if (Mathf.Abs (Vector3.Dot (transform.forward, nomVec)) > 0.99) {		
				radius = Mathf.Sqrt(Mathf.Pow(scale.x/2f,2f) + Mathf.Pow(scale.z/2f,2f));
				startAngleRad = Mathf.Atan2(scale.z, scale.x);
			}

		} else if (Mathf.Abs (Vector3.Dot (transform.up, dirVec)) > 0.99) {					
			if (Mathf.Abs (Vector3.Dot (transform.right, nomVec)) > 0.99) {					
				radius = Mathf.Sqrt(Mathf.Pow(scale.y/2f,2f) + Mathf.Pow(scale.x/2f,2f));
				startAngleRad = Mathf.Atan2(scale.x, scale.y);
			} else if (Mathf.Abs (Vector3.Dot (transform.forward, nomVec)) > 0.99) {		
				radius = Mathf.Sqrt(Mathf.Pow(scale.y/2f,2f) + Mathf.Pow(scale.z/2f,2f));
				startAngleRad = Mathf.Atan2(scale.z, scale.y);
			}
		} else if (Mathf.Abs (Vector3.Dot (transform.forward, dirVec)) > 0.99) {		
			if (Mathf.Abs (Vector3.Dot (transform.right, nomVec)) > 0.99) {					
				radius = Mathf.Sqrt(Mathf.Pow(scale.z/2f,2f) + Mathf.Pow(scale.x/2f,2f));
				startAngleRad = Mathf.Atan2(scale.x, scale.z);
			} else if (Mathf.Abs (Vector3.Dot (transform.up, nomVec)) > 0.99) {				
				radius = Mathf.Sqrt(Mathf.Pow(scale.z/2f,2f) + Mathf.Pow(scale.y/2f,2f));
				startAngleRad = Mathf.Atan2(scale.y, scale.z);
			}
		}

	}
}
