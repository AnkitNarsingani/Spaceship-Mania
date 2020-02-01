using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float health = 100;

    private void Awake()
    {
        if (Instance == null)
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

    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
            GameOver();
    }

    public void Heal(float healAmount)
    {
        health += healAmount;

        if (health > 100)
            health = 100;
    }

    void GameOver()
    {
        UIManager.Instance.SetUIState(UIManager.UIState.Menu);
    }

}
