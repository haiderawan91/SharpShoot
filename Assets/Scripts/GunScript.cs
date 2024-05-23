using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{

    public GameObject scopeOverlay;
    public AudioSource gunshot;
    public float damage = 10f;
    public float range = 20f;
    public Camera fpscam;
    public ParticleSystem muzzleflash;
    public GameObject hitaffect;
    

    public Camera MainCamera;

    // Update is called once per frame
    void FixedUpdate()

    {
       // torch.transform.rotation = this.transform.rotation;
        scopeOverlay.SetActive(false);
        MainCamera.fieldOfView = 60f;
        if (Input.GetButtonDown("Fire1"))
        {
            muzzleflash.transform.rotation = this.transform.rotation;
            shoot();
        }

    }
    void shoot()
    {
        RaycastHit shot;
        Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out shot, range);
        {
           gunshot.Play();
            muzzleflash.Play();
            GetComponent<Animation>().Play("m9fire");
           GameObject inst= Instantiate(hitaffect, shot.point, Quaternion.LookRotation(shot.normal));
            Destroy(inst, 2f);
            
            TargetScript target = shot.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                target.takedamage(10);
            }


            if (shot.collider.tag == "ObstacleTile")
            {
                ScoreScript.initialscore -= 1;
            }
        }

    }
    }
