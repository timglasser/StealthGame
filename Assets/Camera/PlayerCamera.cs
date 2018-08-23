/********************************************************
 * 														*
 * ScriptName:   PlayerCamera.cs						*
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

public class PlayerCamera : MonoBehaviour {
	
	#region PlayerCamera Parameter Vars
	public float ShakeFactor = 55f;
	private float ShakeTime = 0.15f;
	private float ShakeRate = 0.01f;	
	
	private float PersentShakeFactor = 0f;
	private float ShakeTimeReady = 0f;
	private float ShakeRateReady = 0f;
	
	private Transform MyTransform = null;	
	private Vector3 DefaultPosition;
	
	private bool Shake = false;
	
	public float Rotation = 0.0f;
	#endregion
	
	#region Awake	
	void Awake () 
	{
		MyTransform = transform;
		DefaultPosition = MyTransform.localPosition;
	}
	#endregion
	
	#region Update
	void Update () 
	{
		Rotation = Mathf.Clamp ( Rotation, -20f, 15f );		// rotating the camera	
		transform.localEulerAngles = new Vector3( -Rotation, transform.localEulerAngles.y, 0f );
		
		if ( Shake )
		{
			if ( ShakeTimeReady < ShakeTime )
			{				
				ShakeTimeReady += Time.deltaTime;
				
				if ( ShakeRateReady < ShakeRate )
				{
					ShakeRateReady += Time.deltaTime;
					MyTransform.Translate ( 0f, PersentShakeFactor * Time.deltaTime, 0f );
				}
				else
				{
					MyTransform.Translate ( 0f, -PersentShakeFactor * Time.deltaTime, 0f );					
					ShakeRateReady = 0f;					
				}								
			}
			else
			{
				Shake = false;
				ShakeTimeReady = 0f;
				ShakeRateReady = 0f;
				MyTransform.localPosition  =  DefaultPosition;
			}
		}
	}
	#endregion
	
	#region CameraShake
	public void CameraShakeOneShot( float BulletImpulse )
	{
		PersentShakeFactor = ( ( ShakeFactor / 100f ) * ( BulletImpulse / 100f ) );
		ShakeTime = 0.015f;
		Shake = true;
	}
	#endregion
	
	#region CameraShake
	public void CameraShake( float ToTargetDistance, float ToShakeDistance )
	{			
		if ( ToTargetDistance < ToShakeDistance )
		{		
			float PersentShakeStrenght = 100f - ( ToTargetDistance / ToShakeDistance * 100f );
			PersentShakeFactor = ( ShakeFactor * PersentShakeStrenght / 100f );		
			ShakeTime = 0.15f;
			Shake = true;
		}
	}
	#endregion
}