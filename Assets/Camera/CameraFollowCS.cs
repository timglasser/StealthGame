using UnityEngine;
using System.Collections;

public class CameraFollowCS : MonoBehaviour {

	public Transform target, lookat;

	// The distance in the x-z plane to the target
	public float distance = 10.0f;

	// the height we want the camera to be above the target
	public float height = 5.0f;
	
	//smooth the camera as it moves toward the target
	public float smooth = 3.0f;

	/*
	private void smoothPos(Vector3 fromPos, Vector3 toPos){
	
		this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref smoothVel, Time.deltaTime*smooth);
	}
*/
	private void avoidWalls(Vector3  cam, Vector3 target){

		// Draw ray from target to camera. Where it hits the wall position the camera
		Debug.DrawLine (cam, target, Color.red);
		RaycastHit toWall = new RaycastHit();
		if (Physics.Linecast(target, cam, out toWall)){
			// set x and z camera positions to wall hit
			//Debug.Log("collision");
			gameObject.transform.position = new Vector3(toWall.point.x,cam.y,toWall.point.z);
		}
	}


	// Update is called once per frame
	void LateUpdate () {
		// Early out if we don't have a target
		if (!target)
			return;
		
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		
		float wantedHeight = target.position.y + height;
		float currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, smooth * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, smooth * Time.deltaTime);
		
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		gameObject.transform.position = target.position;
		gameObject.transform.position -= currentRotation * Vector3.forward * distance;
		
		// Set the height of the camera
		gameObject.transform.position +=  new Vector3(0.0f,height,0.0f);

	//	avoidWalls ( gameObject.transform.position, lookat.position);

		// Always look at the target
		gameObject.transform.LookAt (lookat);	
		
	}		
}

