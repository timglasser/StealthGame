using UnityEngine;
using System.Collections;

public class ConstraintScript : MonoBehaviour {
	
	public Transform ConstrainTo;
    public Vector3 Offset ;
	public bool pos=false;
	public bool rot=false;


	// Use this for initialization
	void Awake () {
        // set constraint to start position
        transform.position = ConstrainTo.position;
        transform.rotation = ConstrainTo.rotation;

    }
	
	// Late Update is called after all animation etc.
	void LateUpdate () {
		if( pos){
			transform.position=ConstrainTo.position + Offset;
		}
		if( rot){
			
			transform.rotation=ConstrainTo.rotation;
		}		
	}
}
