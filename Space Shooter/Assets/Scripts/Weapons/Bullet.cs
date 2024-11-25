using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _bulletSpeed;
    private float bulletDamage;

    public void InitializeBullet(Weapon firingWeapon)
    {
        bulletDamage = firingWeapon.Damage;
    }

    // apply constant force up until it collides with something
    private void Start()
    {
        _rb.velocity = transform.up * _bulletSpeed; // gives the 'up' direction relative to the bullet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.CompareTag("Enemy"))
        {

            collision.rigidbody.GetComponent<Character>().HealthValue.DecreaseHealth(bulletDamage);
        }

        Destroy(gameObject);
    }
}
