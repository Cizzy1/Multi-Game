using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firepoint;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            shoot();
            Debug.Log("Player has shot");
        }
    }
    
    void shoot(){
        GameObject clone = Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
        Destroy(clone, 10f);
    }
}
