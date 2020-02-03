using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public enum UIState { Menu, Running, GameOver }

    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject RunningPanel;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject InsPanel;
    [SerializeField] Text ScoreInGame;
    [SerializeField] Text ScoreGameOver;

    [Space]
    [Space]

    [SerializeField] Image healthBar;

    private float score = 0;

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
        Pause();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, GameManager.Instance.health / 100, Time.deltaTime * 7);
        score += Time.deltaTime;
        ScoreInGame.text = score.ToString("F0");
        ScoreGameOver.text = score.ToString("F0");
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
                Pause();
                break;

        }

    }

    public void Resume(Animator a)
    {
        a.SetTrigger("Play");
        StartCoroutine("StartPlaying");
    }

    private IEnumerator StartPlaying()
    {
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("True");
        InsPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        InsPanel.SetActive(false);
        Time.timeScale = 1;
        SetUIState(UIState.Running);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;

    }
}
