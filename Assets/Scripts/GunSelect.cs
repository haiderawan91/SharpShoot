using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelect : MonoBehaviour
{
    public GameObject gunchanger;
    public int selectedweapon = 0;

    private bool IsScoped = false;
    private void Start()
    {
        SelectWeapon();
    }
    private void Update()
    {

      

        int prevweapon = selectedweapon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedweapon >= transform.childCount - 1)
            {
                selectedweapon = 0;
            }
            else
            {
                selectedweapon++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedweapon <= 0)
            {
                selectedweapon = transform.childCount - 1;
            }
            else { selectedweapon--; }
        }
        if(prevweapon != selectedweapon)
        {
            SelectWeapon();
        }
        
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform) {

            if (i == selectedweapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

}
