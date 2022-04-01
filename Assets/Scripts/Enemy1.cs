using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public class Enemy1 : Enemy
{
    // POLYMORPHISM
    public override void DoDamage()
    {
        MainManager.Instance.health -= 2;
    }
    // POLYMORPHISM
    public override void Speed()
    {
        speed = 10.0f;
    }

}
