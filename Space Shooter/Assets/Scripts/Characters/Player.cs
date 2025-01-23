using UnityEngine;
public class Player : Character
{
    [SerializeField] private Transform playerWeaponTip;
    //[SerializeField] private Bullet bulletReference;
    protected override void Start()
    {
        base.Start(); // so we get the stuff defined in base class start method (i.e, health object)
        // don't need to instantiate a weapon cuz we're using scriptable objects
        // CurrentWeapon = new ProjectileWeapon(playerWeaponTip, bulletReference);
        CurrentWeapon.StartShooting(playerWeaponTip);
    }

    public override void StartAttack()
    {
        base.StartAttack();
        CurrentWeapon.StartShooting(playerWeaponTip);
    }

    public override void StopAttack()
    {
        base.StopAttack();
        CurrentWeapon.StopShooting();
    }

    public override void Attack()  
    {
        base.Attack();

        CurrentWeapon.Shoot(playerWeaponTip);
    }
}
