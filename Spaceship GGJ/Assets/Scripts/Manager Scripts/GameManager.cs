using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    float health;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float getCurrentHealth()
    {
        return health;
    }

    public void takeDamage(float DamageAmount)
    {
        health -= DamageAmount;
    }

    public void heal(float HealAmount)
    {
        health += HealAmount;
    }
}
