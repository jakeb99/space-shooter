using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp
{
    [SerializeField] private int coinValue;
    protected override void PickMeUp(Player playerInTrigger)
    {
        GameManager.Instance.scoreManager.IncreaseScoreByAmount(coinValue);
    }
}
