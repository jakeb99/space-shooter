using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.CompareTag("Player"));
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("collided with player");
            Destroy(gameObject);
        }
    }

    public override void Attack()
    {
        // do nothing
    }
}
