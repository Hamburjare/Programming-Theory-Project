using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Speed();
    }

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

    public virtual void DoDamage()
    {
        MainManager.Instance.health -= 1;
    }

    public virtual void Speed()
    {
        speed = 4.0f;
    }
}
