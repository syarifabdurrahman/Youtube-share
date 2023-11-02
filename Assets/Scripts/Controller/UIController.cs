using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("UI Reference")]
    public GameObject mainPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject countdownPanel;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI coinTextEnd;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI timeTextEnd;


    public void StartGameUI()
    {
        countdownPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void UpdateTimeUI(string time)
    {
        timeText.text = time;
    }

    public void UpdateTimeCountdown(string countdown)
    {
        countdownText.text = countdown;
    }

    public void Paused()
    {
        mainPanel.SetActive(false);

        pausePanel.SetActive(true);

        GameController.instance.isPaused = true;
    }

    public void GameOverUI()
    {
        coinTextEnd.text = PlayerPrefs.GetInt("coin").ToString();

        mainPanel.SetActive(false);

        gameOverPanel.SetActive(true);
    }

    public void UpdateBestTimeEnd(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeTextEnd.text = $"Best Time Complete: \n {formattedTime}";
    }

    public void UpdateUIText(string coin)
    {
        coinText.text = $"{coin} CO";
        coinTextEnd.text = coinText.text; // or coinTextEnd.text =  PlayerPrefs.GetInt("total")
    }

    #region Button Handler
    public void Resume()
    {
        pausePanel.SetActive(false);

        mainPanel.SetActive(true);

        GameController.instance.isPaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    #endregion
}
