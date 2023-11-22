using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifespan = 2f;

    void Start()
    {
        Destroy(gameObject, lifespan); // Destroy bullet after a certain time to prevent memory leaks
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Move the bullet forward
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet Trigger");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject); // Destroy the bullet when it hits something
        }

        //Destroy(other.gameObject);
        //Destroy(gameObject); // Destroy the bullet when it hits something
    }
}
