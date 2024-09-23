using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text maxScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject levelIsEndPanel;
    [SerializeField] private float levelTime;

    public static Action OnDisableInput;
    public static Action OnEnableInput;
    //public static Action OnUpdateScore;

    private int _currentScore;

    private void Start()
    {
        if (timerText)
            timerText.text = levelTime.ToString();

        if(PlayerPrefs.HasKey("Score") && SceneManager.GetActiveScene().buildIndex == 0)
        {
            maxScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }

    //private void UpdateScore()
    //{
    //    _currentScore++;
    //    if (PlayerPrefs.GetInt("Score") < _currentScore)
    //    {
    //        PlayerPrefs.SetInt("Score", _currentScore);
    //    }
    //    else
    //        _currentScore--;
    //    scoreText.text = _currentScore.ToString();
    //}
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            Timer();
    }

    private void Timer()
    {
        timerText.text = Mathf.Round(levelTime).ToString();
        levelTime -= 1 * Time.deltaTime;
        if (levelTime <= 0)
        {
            Time.timeScale = 0;
            OnDisableInput?.Invoke();
            levelIsEndPanel.SetActive(true);
        }
    }

    public void PauseButton(GameObject pausePanel)
    {
        OnDisableInput?.Invoke();
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ReturnToLevelButton(GameObject pausePanel)
    {
        OnEnableInput?.Invoke();
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void PlayButton(GameObject playPanel)
    {
        playPanel.SetActive(true);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
  
    public void RestartLevelButton(GameObject pausePanel)
    {
        pausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}