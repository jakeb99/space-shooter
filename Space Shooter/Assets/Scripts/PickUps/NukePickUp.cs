using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NukePickUp : PickUp
{
    protected override void PickMeUp(Player playerInTrigger)
    {
        List<Enemy> enemyListCopy = GameManager.Instance.aliveEnemiesList.ToList();
        for (int i = 0; i < enemyListCopy.Count; i++)
        {
            enemyListCopy[i].HealthValue.DecreaseHealth(1000);
        }
    }
}
