using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M107sscript : MonoBehaviour
{

    public static int Ammo = 10;
    public int totalammo;
    public Text Ammodisplay;

    public AudioSource gunshot;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public ParticleSystem muzzleflash;
    public GameObject hitaffect;

    // Update is called once per frame
    void Update()
    {
        if (Ammotext.Ammo > 0)
        {
            while(Input.GetButtonDown("Fire1"))
            {
                Ammotext.Ammo = Ammotext.Ammo - 1;
                muzzleflash.transform.rotation = this.transform.rotation;
                shoot();
            }
          
        }
        totalammo = Ammo;
        Ammodisplay.text = "Ammo: " + totalammo;
        

    }

    void shoot()
    {
        {
            RaycastHit shot;
            Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out shot, range);
            {
                gunshot.Play();
                muzzleflash.Play();
                GetComponent<Animation>().Play("m107gunshot");
                GameObject inst = Instantiate(hitaffect, shot.point, Quaternion.LookRotation(shot.normal));
                Destroy(inst, 2f);
                TargetScript target = shot.transform.GetComponent<TargetScript>();
                if (target != null)
                {
                    target.takedamage(10);
                }
            }
        }

    }
}
           