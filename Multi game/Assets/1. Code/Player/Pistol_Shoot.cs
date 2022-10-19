using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_Shoot : MonoBehaviour
{
    public float gunDamage;
    public float gunRange;
    public float fireRate;
    public GameObject firePoint;

    private float nextFire;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextFire){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;
        nextFire = Time.time + fireRate;
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange)){
            Debug.Log(hit.transform.name);
        }
    }
}
