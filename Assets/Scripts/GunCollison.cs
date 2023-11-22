using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollison : MonoBehaviour
{
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "VoidBullet")
        {
           Destroy(this.gameObject);
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VoidBullet")
        {
            Destroy(this.gameObject);
        }
    }
}
