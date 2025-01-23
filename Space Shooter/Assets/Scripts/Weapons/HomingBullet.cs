using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    protected Player target;

    private void Start()
    {
        target = FindObjectOfType<Player>();
    }

    protected void Update()
    {
        MoveBullet();
        Destroy(gameObject, bulletTime);
    }

    protected override void MoveBullet()
    {
        if (!target) return;    

        Vector2 destination = target.transform.position;
        Vector2 orgin = transform.position;
        Vector2 direction = destination - orgin;

        _rb.velocity = direction * _bulletSpeed;
    }
}
