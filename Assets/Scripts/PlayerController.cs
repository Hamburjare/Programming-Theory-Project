using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float xRange = 9;
    public GameObject projectilePrefab;

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (!MainManager.Instance.isGameOver)
        {
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !MainManager.Instance.isGameOver)
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
    }
    // ABSTRACTION
    void BetweenBounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
