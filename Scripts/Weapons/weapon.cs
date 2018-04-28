using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    private Animator anim;
    private AudioSource _AudioSoource;
    public float range = 100f;
    public int bulletsPerMag = 30;
    public int bulletsLeft;
    public int currentBullets;

    public Transform shootPoint;
    public ParticleSystem muzzleFlash;
    public AudioClip shootsound;
    

    public float fireRate = 0.1f;
    float fireTimer;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        _AudioSoource = GetComponent<AudioSource>();
        currentBullets = bulletsPerMag;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
	}
   /* void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("fire")) anim.SetBool("fire", false);
    }*/

    private void Fire()
    {
        if (fireTimer < fireRate) return;
        Debug.Log("Fire-d!");
        RaycastHit hit;
        

        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "found!");
        }

        muzzleFlash.Play();
        PlayShootSound();
        anim.SetBool("Fire", true);
        currentBullets--;
        fireTimer = 0.0f;
    }
    public void PlayShootSound()
    {
        _AudioSoource.clip = shootsound;
        _AudioSoource.Play();
    }
}
