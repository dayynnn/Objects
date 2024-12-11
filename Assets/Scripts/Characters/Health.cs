using UnityEngine;
using UnityEngine.Events;

public class Health
{
    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnDeath;
    private float healthValue;
    private Character myCharacter;

    public void DecreaseHealth(float damageParam)
    {
        healthValue -= damageParam;
        Debug.Log("Health decreased to " + healthValue);
        OnHealthChanged.Invoke(healthValue);
        
        //UPDATE UI
        //CHECK IF ISDEAD TRUE
        if (IsDead())
        {
            OnDeath.Invoke();

        }
    }

    public void IncreaseHealth(float increaseParam)
    {
        healthValue += increaseParam;
        OnHealthChanged.Invoke(healthValue);
    }

    public bool IsDead()
    {
        return healthValue <= 0;
    }

    public float GetHealthValue()
    {
        return healthValue;
    }

    public Health()
    {
        healthValue = 100;
        OnDeath = new UnityEvent();
        OnHealthChanged = new UnityEvent<float>();
    } //CHECK CONSTRUCTORS OVERLOAD

    public Health(float initialHealth) //CHECK CONSTRUCTORS OVERLOAD
    {
        healthValue = initialHealth;
        OnDeath = new UnityEvent(); 
        OnHealthChanged = new UnityEvent<float>();
    }
}
