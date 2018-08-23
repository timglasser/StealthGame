using UnityEngine;
using System.Collections;

public class FighterHUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

//	public RigidBody rb;
	private float heading ;
	private float pitch ;
	private float roll ;
	
	void Update () {
/*
		// Heading
		heading = Mathf.Atan2(transform.forward.z, transform.forward.x) * Mathf.Rad2Deg;    

		//pitch
		Vector3 pos = ProjectPointOnPlane(Vector3.up, Vector3.zero, transform.right);
		pitch = SignedAngle(transform.forward, pos, transform.right);
		
	    // roll
		pos = ProjectPointOnPlane(Vector3.up, Vector3.zero, transform.forward);
		roll = SignedAngle(transform.right, pos, transform.forward);

		// yaw
		pos = ProjectPointOnPlane(Vector3.up, Vector3.zero, transform.up);
		roll = SignedAngle(transform.right, pos, transform.forward);

*/
	}

//	void OnGUI() {
	//	GUI.Label(Rect(20,0,100,40), heading.ToString());
	//	GUI.Label(Rect(20,50,100,40), pitch.ToString());
//		GUI.Label(Rect(20,100,100,40), roll.ToString());
//	}
	/*
	function ProjectPointOnPlane(planeNormal : Vector3 , planePoint : Vector3 , point : Vector3 ) : Vector3 {
		planeNormal.Normalize();
		var distance = -Vector3.Dot(planeNormal.normalized, (point - planePoint));
		return point + planeNormal * distance;
		30. }    
	
	function  SignedAngle(v1 : Vector3,v2 : Vector3, normal : Vector3) : float {
		var perp = Vector3.Cross(normal, v1);
		var angle = Vector3.Angle(v1, v2);
		35.     angle *= Mathf.Sign(Vector3.Dot(perp, v2));
		return angle;
	}
*/

}
