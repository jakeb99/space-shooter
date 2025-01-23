
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected Player target;
    [SerializeField] protected float distanceToStop = 2f;
    [SerializeField] protected float attackCooldown = 3f;
    [SerializeField] public EScoreType ScoreType {  get; protected set; }

    [SerializeField] protected float attackTimer;

    [SerializeField] public List<GameObject> PickUps = new List<GameObject>();
    [SerializeField] private float pickUpChance;

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<Player>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (!target) return;

        // move the enemy to the player position
        // direction = destination - current position
        Vector2 destination = target.transform.position;
        Vector2 currentPosition = transform.position;
        Vector2 direction = destination - currentPosition;

        // stop moving when we reach distance to stop
        if(Vector2.Distance(destination, currentPosition) > distanceToStop )
        {
            Move(direction.normalized);
        } else
        {
            Attack();
        }

        Look(direction.normalized);
    }

    public override void Attack()
    {
        base.Attack();
        // check if we can attack
        if(attackTimer >= attackCooldown)
        {
            //target.HealthValue.DecreaseHealth(1);
            attackTimer = 0; // reset timer
        }
        else
        {
            attackTimer += Time.deltaTime;
        }
    }

    public override void CharacterDied()
    {
        // spawn pickup
        if (ShouldDropPickup())
        {
            int rollIndex = Random.Range(0, PickUps.Count);
            Instantiate(PickUps[rollIndex], transform.position, transform.rotation);
        }

        GameManager.Instance.RemoveEnemyFromAliveList(this);
        base.CharacterDied();

    }

    private bool ShouldDropPickup()
    {
        float roll = Random.Range(0f, 1f);
        return roll <= pickUpChance;
    }

}

