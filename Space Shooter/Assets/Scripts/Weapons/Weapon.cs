using System.Collections;
using UnityEngine;
public abstract class Weapon : ScriptableObject
{
    [SerializeField] public float Damage;
    [SerializeField] public int AmmoCount;
    [SerializeField] public float FireRate;
    [SerializeField] protected bool isShooting;

    public abstract void Shoot(Transform weaponTip);

    public abstract void StartShooting(Transform weaponTip);

    public abstract void StopShooting();

    public abstract void Reload();

    public bool hasAmmo()
    {
        return AmmoCount > 0;
    }
}
