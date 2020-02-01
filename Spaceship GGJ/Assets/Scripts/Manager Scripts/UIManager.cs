using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
   public enum UIState { Menu, Running, Paused,GameOver }

    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject RunningPanel;
    [SerializeField] GameObject PausedPanel;
    [SerializeField] GameObject GameOverPanel;

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
        SetUIState(UIState.Menu);

    }

    // Update is called once per frame
   

   public void SetUIState(UIState uIState)
    {
        switch (uIState)
        {
            case UIState.Menu:
                MenuPanel.SetActive(true);

                RunningPanel.SetActive(false);
                PausedPanel.SetActive(false);
                GameOverPanel.SetActive(false);
                break;
            case UIState.Running:
                RunningPanel.SetActive(true);

                MenuPanel.SetActive(false);
                PausedPanel.SetActive(false);
                GameOverPanel.SetActive(false);
                break;
            case UIState.Paused:
                PausedPanel.SetActive(true);

                RunningPanel.SetActive(false);
                MenuPanel.SetActive(false);
                GameOverPanel.SetActive(false);
                break;
            case UIState.GameOver:
                GameOverPanel.SetActive(true);

                PausedPanel.SetActive(false);
                RunningPanel.SetActive(false);
                MenuPanel.SetActive(false);
                break;

        }

    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Pause()
    {
        Time.timeScale = 0;

    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
