using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public enum UIState { Menu, Running,  GameOver }

    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject RunningPanel;
    [SerializeField] GameObject GameOverPanel;

    [Space]
    [Space]

    [SerializeField] Image healthBar;

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
        //SetUIState(UIState.Menu);
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, GameManager.Instance.health / 100, Time.deltaTime * 7);
    }

    public void SetUIState(UIState uIState)
    {
        switch (uIState)
        {
            case UIState.Menu:
                MenuPanel.SetActive(true);

                RunningPanel.SetActive(false);
                GameOverPanel.SetActive(false);
                break;
            case UIState.Running:
                RunningPanel.SetActive(true);

                MenuPanel.SetActive(false);
                GameOverPanel.SetActive(false);
                break;
          
            case UIState.GameOver:
                GameOverPanel.SetActive(true);

                RunningPanel.SetActive(false);
                MenuPanel.SetActive(false);
                break;

        }

    }


    public void LoadLevel(string levelName)
    {
        SetUIState(UIState.Running);
        SceneManager.LoadScene(levelName);
    }

    public void Pause()
    {
        Time.timeScale = 0;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        SetUIState(UIState.Running);
    }

    public void Quit()
    {
        Application.Quit();

    }
}
