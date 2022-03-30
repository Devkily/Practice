using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunSA : WeaponSA
{
    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        }
        
    }
}
