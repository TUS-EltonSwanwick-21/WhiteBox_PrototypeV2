using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject regularBulletPrefab;
    public GameObject voidBulletPrefab;
    public Transform firePoint;

    public string ammoType = "Regular";
    private Renderer gunRender;

    public Material regularMaterial;
    public Material voidMaterial;
    // Start is called before the first frame update
    void Start()
    {
        gunRender = GetComponent<Renderer>();
        gunRender.material = regularMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Ammo Switched");
            SwitchAmmo();
            
        }
    }



    void Fire()
    {

        Debug.Log("Firing");
        Vector3 spawnPosition = firePoint.position;
        Quaternion spawnRotation = firePoint.rotation;

        if (ammoType == "Regular" && regularBulletPrefab != null)
        {
            Instantiate(regularBulletPrefab, spawnPosition, spawnRotation);
        }
        else if(ammoType == "Void" && voidBulletPrefab != null)
        {
            Instantiate(voidBulletPrefab, spawnPosition, spawnRotation);
        }
    }


    void SwitchAmmo()
    {
        if(ammoType == "Regular")
        {
            ammoType = "Void";
            gunRender.material = voidMaterial;

        }
        else
        {
            ammoType = "Regular";
            gunRender.material = regularMaterial;
        }
    }
}
