/********************************************************
 * 														*
 * ScriptName:   BulletDecal.cs							*
 * 														*
 * Copyright(c): Victor Klepikov						*
 * Support: 	 ialucard4@gmail.com					*
 * 														*
 * MyAssets:     http://goo.gl/8ncIsT					*
 * MyTwitter:	 http://twitter.com/VictorKlepikov		*
 * MyFacebook:	 http://www.facebook.com/vikle4 		*
 * 														*
 ********************************************************/


using UnityEngine;
using System.Collections;

public class BulletDecal : MonoBehaviour {
		
	public float LifeTime = 1.5f;
	private float ReadyTime = 0f;	
		
	public ParticleSystem prtDefaultClone = null;
	public ParticleSystem prtConcreteClone = null;
	public ParticleSystem prtWoodClone = null;
	public ParticleSystem prtMetalClone = null;
	public ParticleSystem prtGroundClone = null;
	public ParticleSystem prtBodyClone = null;	
	
	void Update () 
	{
		ReadyTime += Time.deltaTime; 
		if ( ReadyTime > LifeTime )						
		{				
			ReadyTime = 0f;
		//	gameObject.SetActive( false );			
		}
	}	
}
