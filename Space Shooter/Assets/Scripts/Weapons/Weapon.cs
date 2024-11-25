using UnityEngine;
public abstract class Weapon : ScriptableObject
{
    [SerializeField] public float Damage;
    [SerializeField] public int AmmoCount;
    [SerializeField] public float FireRate;

    // we can't drag and drop weapon tip since this is a scritable object and is not part of the scene
    //protected Transform weaponTip;    // point that bullet fires from

    // don't need constructor when using scriptable object
    //public Weapon(Transform weaponTip) 
    //{  
    //    this.weaponTip = weaponTip; 
    //}
    public abstract void Shoot(Transform weaponTip);

    public abstract void Reload();

    public bool hasAmmo()
    {
        return AmmoCount > 0;
    }
}
