

using UnityEngine;

// need this to create scriptable object menu in editor
[CreateAssetMenu(fileName = "New Weapon", menuName = "Projectile Weapon")]
public class ProjectileWeapon : Weapon
{
    [SerializeField] private Bullet _projectilePrefab;

    // don't need constructors when using scriptable objects
    //public ProjectileWeapon(Transform  weaponTip, GameObject projectilePrefab) : base(weaponTip)
    //{
    //    _projectilePrefab = projectilePrefab;
    //}

    //public ProjectileWeapon(Transform weaponTip) : base(weaponTip)
    //{
    //}

    public override void Shoot(Transform weaponTip)
    {
        Bullet bullteClone = GameObject.Instantiate(_projectilePrefab, weaponTip.position, weaponTip.rotation);
        bullteClone.InitializeBullet(this);    
    }

    public override void Reload()
    {

    }

}
