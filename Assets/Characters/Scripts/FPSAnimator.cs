using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class FPSAnimator : MonoBehaviour {

	Animator anim;

	int speedHash = Animator.StringToHash("TotalSpeed");
	int forwardHash = Animator.StringToHash("ForwardSpeed");
	int strafeHash = Animator.StringToHash("StrafeSpeed");
	int shootHash = Animator.StringToHash("Shoot");
	int aimHash = Animator.StringToHash("Aim");
	int reloadHash = Animator.StringToHash ("Reload");

	float horizontal;
	float vertical;
	bool aim;
	bool fire;
	bool jump;
	bool reload;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat(speedHash, Mathf.Abs (horizontal)+Mathf.Abs (vertical));
		anim.SetFloat (forwardHash, vertical);
		anim.SetFloat(strafeHash, horizontal);
        anim.SetBool(shootHash, fire);
		anim.SetBool (aimHash, aim);
		anim.SetBool (reloadHash, reload);
	}

	public void UpdateValues(float _h, float _v, bool _aim, bool _fire, bool _jump, bool _reload){
		horizontal = _h;
		vertical = _v;
		aim = _aim;
		fire = _fire;
		jump = _jump;
		reload = _reload;
	}
}
