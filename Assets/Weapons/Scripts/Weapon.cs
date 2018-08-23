

 //Tim Glasser from a script by Victor Klepikov


using UnityEngine;
using System.Collections;



public class Weapon : MonoBehaviour {
    #region WeaponParameter Vars

 
    public bool UnlimitedAmmo = false;
    public float BulletMass = 3.2f;
    public float BulletSpeed = 40.0f;
    public Vector3 Recoil = new Vector3(0.0f, 0.0f, 0.0f);
//    public int ShotGunBulletClones = 10;

    public GameObject mBullet;
    public Transform Muzzle = null;

    public GameObject mShell;
    public Transform ShellEjector = null;

    public AudioClip ShotSFX = null;
    public AudioClip EmptySFX = null;
    public AudioClip ReloadSFX = null;
    public AudioSource AudioSource = null;

    public GameObject MuzzleFlash = null;
    public GameObject MuzzleSmoke = null;

    public float Dispersion_X = 100f;
    public float Dispersion_Y = 75f;
    public float DispersionSize = 1f;
    public float MaxDispersionSize = 2.2f;
    public float IncDispersionSize = 0.125f;
    public float DecDispersionSize = 0.045f;
    private bool DSDefault = true;

    public int MaxAmmoInClip = 30;
    public int CurrentAmmoInClip = 30;
    public int MaxAmmoInPocket = 300;// 10 clips
    public int CurrentAmmoInPocket = 300;

    public float Range = 1000;

    private float DispersionTime = 0f;
  
    private Animator state;
    #endregion


    #region Init
    void Awake()
    {
        state = GetComponent<Animator>();
    }

    void Start()
    {
        Muzzle = transform.Find("Muzzle");
        ShellEjector = transform.Find("ShellEjector");
        AudioSource = Muzzle.GetComponent<AudioSource>();
    }
    #endregion


    #region ChangeDispersionSize
    /*
	private void ChangeDispersionSize()
	{
		DispersionTime += Time.deltaTime;
		if ( DispersionTime > 0.8f )
		{
			DispersionSize -= DecDispersionSize;
			
			if ( DispersionSize < 0.12 )
			{
				DSDefault = true;
				DispersionTime = 0f;				
			}
		}
	}
    */
    #endregion

    #region Messages
    public void OnImpact() {
        RaycastHit hit;
        var ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, Range)) {
            var effect = ImpactManager.Instance.GetImpactEffect(hit.transform.gameObject);
            if (effect == null)
                return;
            var effectIstance = MyCache.Spawn(effect, hit.point, new Quaternion()) as GameObject;             
            effectIstance.transform.LookAt(hit.point + hit.normal);
          //  MyCache.Destroy(effectIstance, 4); // de-activate after 4 secs
        }
    }

    public void OnStartFireMsg()
    {
        state.SetBool("trigger", true);
    }

    public void OnEndFireMsg()
    {
        state.SetBool("trigger", false);
        MuzzleSmoke.SetActive(true);

    }
    #endregion
}