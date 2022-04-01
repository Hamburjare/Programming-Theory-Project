using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public class Enemy2 : Enemy
{
    // POLYMORPHISM
    public virtual void Speed()
    {
        speed = 8.0f;
    }
}
