
using UnityEngine;
using UnityEngine.Events;

public class Health
{
    private float healthValue;

    public UnityEvent OnDied;
    public UnityEvent<float> OnHealthUpdate;

    public Health (float initialHealthValue = 100f)
    {
        this.healthValue = initialHealthValue;

        OnDied = new UnityEvent();

        // QUESTION how come we need to init the unity event for health but not for updatescore event?
        OnHealthUpdate = new UnityEvent<float>();
    }

    public float GetHealthValue()
    {
        return healthValue;
    }

    public void DecreaseHealth(float damageAmount)
    {
        healthValue -= damageAmount;
        Debug.Log($"health is {healthValue}");

        // tell listeners that the health has changed
        OnHealthUpdate.Invoke(healthValue);

        if (IsDead())
        {
            OnDied.Invoke();
        }


    }

    public void IncreaseHealth(float increaseAmount)
    {
        healthValue += increaseAmount;

        // tell listeners that the health has changed
        OnHealthUpdate.Invoke(healthValue);
    }

    public bool IsDead()
    {
        return healthValue <= 0;
    }

}