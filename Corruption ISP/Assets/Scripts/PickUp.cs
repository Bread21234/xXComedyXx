using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
//pickup values
    public Rigidbody2D rb;

    public Transform gunHolder;
// WeaponSwitch values
     public int selectedWeapon = 0;

   // Start is called before the first frame update
    void Start()
    {
        SelectWeapon(gunHolder);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //takes in scroll wheel and changes the index of which weapon is being used.
        {
            if (selectedWeapon >= gunHolder.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon ++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = gunHolder.childCount - 1;
            else
                selectedWeapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gunHolder.childCount >= 2)
        {
            selectedWeapon = 1;
        }
        if (previousSelectedWeapon != selectedWeapon) //checks if the index has changed
        {
            SelectWeapon(gunHolder); //calls func to switch the weapon to the new index
        }
    }
    public void SelectWeapon(Transform gunHolder)
    {
        int i = 0;
        foreach (Transform weapon in gunHolder)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true); //activates the weapon with the correlating index.
            else
                weapon.gameObject.SetActive(false); //makes every other weapon inactive
            i++;
        }
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        ShootScript gun = hitInfo.GetComponent<ShootScript>(); //checks if interacts with something with a shootscript
        if (gun != null)
        {
            addGun(gunHolder, gun);
           // Destroy(gun);
        }
        SelectWeapon(gunHolder);
    }

    void addGun(Transform gunHolder, ShootScript gun)
    {
        gun.transform.SetParent(gunHolder);
        gun.transform.localPosition = new Vector3((float)-9.2,(float)-.2,0); //change when get actual weapons
    }
}


