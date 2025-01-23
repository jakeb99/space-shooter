

using UnityEngine;

// need this to create scriptable object menu in editor
[CreateAssetMenu(fileName = "New Weapon", menuName = "Projectile Weapon")]
public class ProjectileWeapon : Weapon
{
    [SerializeField] private Bullet _projectilePrefab;

    public override void StartShooting(Transform weaponTip)
    {
        isShooting = true;
        Shoot(weaponTip);
        
        StopShooting();
    }

    public override void Reload()
    {

    }

    public override void Shoot(Transform weaponTip)
    {
        if (isShooting)
        {
            Bullet bullteClone = GameObject.Instantiate(_projectilePrefab, weaponTip.position, weaponTip.rotation);
            AudioManager.Instance.PlaySFX("Lazer");
            bullteClone.InitializeBullet(this);
            //if (FireDelay >= 1 / FireRate)
            //{
            //    //canShoot = false;
            //    Bullet bullteClone = GameObject.Instantiate(_projectilePrefab, weaponTip.position, weaponTip.rotation);
            //    bullteClone.InitializeBullet(this);
            //    FireDelay = 0;
            //}
            //else
            //{
            //    FireDelay += Time.deltaTime;
            //}


        }
    }

    public override void StopShooting()
    {
        isShooting = false;
    }


}
