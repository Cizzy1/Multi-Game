using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nade_Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float bulletSpeed;
    public GameObject partical_effect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Target"){
            Destroy(col.gameObject);
        }

        GameObject clone = Instantiate(partical_effect, transform.position, transform.rotation);

        Destroy(this.gameObject);

    }
}
