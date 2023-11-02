using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI cointTotalText;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #region Other

    private void Start()
    {
        UpdateBestTime(PlayerPrefs.GetFloat("best time"));
        UpdateCoinUIText(PlayerPrefs.GetInt("total").ToString());
    }

    public void UpdateBestTime(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        bestTimeText.text = $"Best Time Complete: \n {formattedTime}";
    }

    public void UpdateCoinUIText(string coin)
    {
        cointTotalText.text = $"{coin} CO";
        // or coinTextEnd.text =  PlayerPrefs.GetInt("total")
    }

    #endregion
}
