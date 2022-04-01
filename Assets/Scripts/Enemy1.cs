using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public override void DoDamage()
    {
        MainManager.Instance.health -= 2;
    }

    public override void Speed()
    {
        speed = 10.0f;
    }

}
