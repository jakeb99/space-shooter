using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleEnemy : Enemy
{
    [SerializeField] private Transform weaponTip;

    public override void Attack()
    {
        if (attackTimer >= attackCooldown)
        {
            CurrentWeapon.StartShooting(weaponTip);
            attackTimer = 0;
        } else
        {
            attackTimer += Time.deltaTime;
        }
    }
}
