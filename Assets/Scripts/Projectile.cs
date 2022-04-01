using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.z > 7)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
