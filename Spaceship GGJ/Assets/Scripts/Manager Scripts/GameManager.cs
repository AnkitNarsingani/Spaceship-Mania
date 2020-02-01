using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public float Health=100;

    CameraShake cameraShake;
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
    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
    }

    public float getCurrentHealth()
    {
        return Health;
    }

    public void TakeDamage(float DamageAmount)
    {
        Health -= DamageAmount;
        if(Health<=0)
        {
            GameOver();
        }
        if(cameraShake)
        cameraShake.ShakeIt();

    }

    public void heal(float HealAmount)
    {
        Health += HealAmount;
    }

    void GameOver()
    {
        UIManager.Instance.SetUIState(UIManager.UIState.Menu);
    }

}
