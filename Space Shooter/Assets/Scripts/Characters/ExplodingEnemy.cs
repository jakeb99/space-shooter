using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    [SerializeField] float explosionDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.CompareTag("Player"));
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("collided with player");
            Attack();
            Destroy(gameObject);
        }
    }

    public override void Attack()
    {
        //base.Attack();
        target.HealthValue.DecreaseHealth(explosionDamage);
    }
}
