using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Enemy : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Speed();
    }
    // ABSTRACTION
    void Move()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        Move();
        if (transform.position.z < -7)
        {
            Destroy(gameObject);
            DoDamage();
        }
    }
    // ABSTRACTION
    public virtual void DoDamage()
    {
        MainManager.Instance.health -= 1;
    }
    // ABSTRACTION
    public virtual void Speed()
    {
        speed = 4.0f;
    }
}
