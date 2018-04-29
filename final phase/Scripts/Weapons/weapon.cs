using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class weapon : MonoBehaviour {

    private Animator anim;
    private AudioSource _AudioSoource;
    public float range = 100f;
    public int bulletsPerMag = 30;
    public int bulletsLeft = 300;
    public int currentBullets;

    public Transform shootPoint;
    public GameObject hitParticles;
    public GameObject bulletImpact;
    public ParticleSystem muzzleFlash;
    public AudioClip shootsound;

    public Text ammotext;
    

    public float fireRate = 0.1f;
    public float damage = 20f;
    float fireTimer;
    private bool isReloading;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        _AudioSoource = GetComponent<AudioSource>();
        currentBullets = bulletsPerMag;
        updateAmootext();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0)
                Fire();
            else
                DeReload(); 
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            if (currentBullets < bulletsPerMag && bulletsLeft > 0)
                DeReload();
        }
        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
	}
    void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        isReloading = info.IsName("Reload");
        //if (info.IsName("fire")) anim.SetBool("fire", false);

    }
    private void Fire()
    {
        if (fireTimer < fireRate || currentBullets <=0 || isReloading) return;
        Debug.Log("Fire-d!");
        RaycastHit hit;
        

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "found!");

            GameObject hitParlclEffectt = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            GameObject bullethole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            Destroy(hitParlclEffectt, 1f);
            Destroy(bullethole, 2f);
            if(hit.transform.GetComponent<HealthController>())
            {
                hit.transform.GetComponent<HealthController>().applyDamage(damage);
            }

        }

        anim.CrossFadeInFixedTime("Fire", 0.1f);

        muzzleFlash.Play();
        PlayShootSound();
        //anim.SetBool("Fire", true);
        currentBullets--;
        updateAmootext();
        fireTimer = 0.0f;
    }

    public void Reload()
    {
        if (bulletsLeft <= 0) return;

        int bulletToLoad = bulletsPerMag - currentBullets;
        int bulletToDetect = (bulletsLeft >= bulletToLoad) ? bulletToLoad : bulletsLeft;
        bulletsLeft -= bulletToDetect;
        currentBullets += bulletToDetect;
        updateAmootext();
    }
    private void DeReload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (isReloading) return;
        anim.CrossFadeInFixedTime("Reload", 0.01f);

    }
    public void PlayShootSound()
    {
        _AudioSoource.clip = shootsound;
        _AudioSoource.Play();
    }

    private void updateAmootext()
    {
        ammotext.text = currentBullets + " / " + bulletsLeft;
    }
}
