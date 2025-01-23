using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected float _bulletSpeed;
    [SerializeField] protected float bulletDamage;
    [SerializeField] protected float bulletTime;

    public virtual void InitializeBullet(Weapon firingWeapon)
    {
        bulletDamage = firingWeapon.Damage;
    }

    // apply constant force up until it collides with something
    private void Start()
    {
        MoveBullet();
    }

    protected virtual void MoveBullet()
    {
        _rb.velocity = transform.up * _bulletSpeed; // gives the 'up' direction relative to the bullet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.CompareTag("Enemy") || collision.rigidbody.CompareTag("Player"))
        {
            collision.rigidbody.GetComponent<Character>().HealthValue.DecreaseHealth(bulletDamage);
            Destroy(gameObject);
        }
    }
}
