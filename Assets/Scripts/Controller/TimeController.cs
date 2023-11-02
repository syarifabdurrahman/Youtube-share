using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool timeActivate;
    public float currentTime;

    public UIController controller;

    public void StartTimer()
    {
        timeActivate = true;
    }

    private void Update()
    {
        if (timeActivate && !GameController.instance.isPaused && GameController.instance.isStarting)
        {
            currentTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            controller.UpdateTimeUI(formattedTime);

        }
    }
}
