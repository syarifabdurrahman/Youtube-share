using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        instance = this;

        isFirstTime = !PlayerPrefs.HasKey("played before");

        if (isFirstTime)
        {
            PlayerPrefs.SetInt("played before", 1);

            bestTime = 0;
        }
        else
        {
            bestTime = PlayerPrefs.GetFloat("best time");
        }
    }

    public bool isStarting = false;
    public bool isPaused = false;
    public bool isFirstTime;

    [Header("CountDownSetting")]
    public int countDownTime;
    public TimeController timeController;
    public UIController controller;

    private float bestTime = 0;

    private void Start()
    {
        StartCountdown();
    }

    private void Update()
    {
        if (!isStarting && isPaused)
        {
            GameTimeCheck();
        }
    }

    private void StartCountdown()
    {
        StartCoroutine(CountdownStart());
    }

    IEnumerator CountdownStart()
    {
        while (countDownTime >= 0)
        {
            // update UI
            controller.UpdateTimeCountdown(countDownTime.ToString());

            yield return new WaitForSeconds(1);

            countDownTime--;
        }

        // time controller
        timeController.StartTimer();

        yield return new WaitForSeconds(.5f);

        // update UI
        controller.StartGameUI();

        isStarting = true;
    }

    public void GameTimeCheck()
    {
        if (isFirstTime)
        {
            PlayerPrefs.SetFloat("best time", timeController.currentTime);
            //Debug.Log("First Time Played! Best Time initialized: " + timeController.currentTime);

            controller.UpdateBestTimeEnd(timeController.currentTime);
        }
        else
        {
            //Debug.Log("Stored Best Time: " + bestTime);

            controller.UpdateBestTimeEnd(bestTime);

            if (timeController.currentTime < bestTime)
            {
                PlayerPrefs.SetFloat("best time", timeController.currentTime);
                //Debug.Log("New Best Time: " + timeController.currentTime);

                controller.UpdateBestTimeEnd(timeController.currentTime);
            }
        }
    }
}
