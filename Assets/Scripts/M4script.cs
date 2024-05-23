using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M4script : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Ammo = 10;
    public int totalammo;
    public Text Ammodisplay;

    
    private bool isfiring = false;

    public AudioSource gunshot;
    public float damage = 10f;
    public float range = 1000f;
    public Camera fpscam;
    public ParticleSystem muzzleflash;
    public GameObject hitaffect;
    //
    public GameObject scopeOverlay;
    public Animator animator;
    public Animator fireanim;
    private bool IsScoped = false;
    
    public Camera MainCamera;

    public float scopedFOV = 15;
    
    //

    // Update is called once per frame
    void Update()
    {
       // torch.transform.rotation = this.transform.rotation;
        if (Input.GetButtonDown("Fire2"))
        {
            IsScoped = !IsScoped;
            animator.SetBool("Scoped", IsScoped);
            scopeOverlay.SetActive(IsScoped);
            if (IsScoped) {
                MainCamera.fieldOfView = 15f;
                    }
            else { MainCamera.fieldOfView = 60f;
            }
        }


        if (Input.GetButtonDown("Fire1"))
        {
            
            
            if (Ammotext.Ammo > 0)
            {
                muzzleflash.transform.rotation = this.transform.rotation;
                Ammotext.Ammo = Ammotext.Ammo - 1;
                shoot();
             //   isfiring = true;
               // fireanim.SetBool("Firing", isfiring);
                //isfiring = false;
            }
            
        }

        if (IsScoped)
            StartCoroutine(OnScoped());
        else
        {
            OnUnScoped();
        }
       

    }
    void shoot()
    {
        RaycastHit shot;
        Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out shot, range);
        {
            GetComponent<Animation>().Play("singleshotm4new");
            gunshot.Play();
            muzzleflash.Play();
            
            GameObject inst = Instantiate(hitaffect, shot.point, Quaternion.LookRotation(shot.normal));
            Destroy(inst, 2f);
           
            TargetScript target = shot.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                target.takedamage(10);
            }
            if(shot.collider.tag == "ObstacleTile")
            {
                ScoreScript.initialscore -= 1;
            }
        }

    }
    void OnUnScoped() {

        scopeOverlay.SetActive(false);
        
       // MainCamera.fieldOfView = normalFOV;

    }

    IEnumerator OnScoped() {

        yield return new WaitForSeconds(.15f);
        scopeOverlay.SetActive(true);
        
        //normalFOV = MainCamera.fieldOfView;
       //MainCamera.fieldOfView = 15;
    }
}
