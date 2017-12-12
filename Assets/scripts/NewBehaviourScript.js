#pragma strict

 var rotator : Transform;
 var speed = 1.0;
 var halfCubeSize = 0.5;
 private var rotating = false;
 
 function RotateCube(refPoint : Vector3, rotationAxis : Vector3)
 {
     rotator.localRotation = Quaternion.identity;
     rotator.position = transform.position -Vector3.up*halfCubeSize + refPoint;
     transform.parent = rotator;
     var angle : float = 0;
     while(angle < 90.0)
     {
         angle += Time.deltaTime*90.0*speed;
         rotator.rotation = Quaternion.AngleAxis(Mathf.Min(angle,90.0),rotationAxis);
         yield;
     }
     transform.parent = null;
     rotating = false;
 }
 
 
 function Start()
 {
     rotator = (new GameObject("Rotator")).transform;
 }
 
 function Update ()
 {
     if (!rotating)
     {
         if (Input.GetKey(KeyCode.D))
         {
             rotating = true;
             RotateCube(Vector3.right*halfCubeSize,-Vector3.forward);
         }
         else if (Input.GetKey(KeyCode.A))
         {
             rotating = true;
             RotateCube(-Vector3.right*halfCubeSize,Vector3.forward);
         }
         else if (Input.GetKey(KeyCode.W))
         {
             rotating = true;
             RotateCube(Vector3.forward*halfCubeSize,Vector3.right);
         }
         else if (Input.GetKey(KeyCode.S))
         {
             rotating = true;
             RotateCube(-Vector3.forward*halfCubeSize,-Vector3.right);
         }
     }
 }