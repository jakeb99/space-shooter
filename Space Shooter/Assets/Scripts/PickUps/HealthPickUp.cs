using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : PickUp
{
    [SerializeField] private float healAmount;
    protected override void PickMeUp(Player playerInTrigger)
    {
        playerInTrigger.HealthValue.IncreaseHealth(healAmount);
    }
}
