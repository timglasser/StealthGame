using UnityEngine;
using System.Collections;

public class ActionFireWeapon : StateMachineBehaviour{

    private Weapon wpn;

    // This will be called when the animator first transitions to this state.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        wpn = animator.gameObject.GetComponent<Weapon>(); 
     
        GameObject go = MyCache.Spawn(wpn.mBullet, wpn.Muzzle.position, wpn.Muzzle.rotation) as GameObject;

        go.transform.position = wpn.Muzzle.position;
        go.transform.rotation = wpn.Muzzle.rotation;

        go.GetComponent<Rigidbody>().velocity = wpn.Muzzle.TransformDirection(Vector3.forward * wpn.BulletSpeed);
        //	go.transform.Rotate( Random.Range ( -Dispersion_Y * 55f, Dispersion_Y * 55f ) * Time.deltaTime, 
        //											 			 Random.Range ( -Dispersion_X * 55f, Dispersion_X * 55f ) * Time.deltaTime, 0.0f );

        wpn.AudioSource.PlayOneShot(wpn.ShotSFX);
        wpn.MuzzleFlash.SetActive(true);
        wpn.transform.localPosition += wpn.Recoil;


        //   decal = MyCache.Spawn(wpn.Bullethole, wpn.Muzzle.position, wpn.Muzzle.rotation) as GameObject;
        //   MyImpactManager.Impact(wpn.Muzzle, wpn.BulletMass, wpn.BulletSpeed, decal);
    }
			
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      

    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        // create the empty shell
        GameObject obj = MyCache.Spawn(wpn.mShell, wpn.ShellEjector.position, wpn.ShellEjector.rotation);

        obj.GetComponent<Rigidbody>().velocity = wpn.ShellEjector.TransformDirection(Vector3.left * 8.0f);

        obj.transform.Rotate(Random.Range(-wpn.Dispersion_Y * 55.0f, wpn.Dispersion_Y * 55.0f) * Time.deltaTime,
                                                          Random.Range(-wpn.Dispersion_X * 55.0f, wpn.Dispersion_X * 55.0f) * Time.deltaTime, 0.0f);

        wpn.OnImpact();

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}















