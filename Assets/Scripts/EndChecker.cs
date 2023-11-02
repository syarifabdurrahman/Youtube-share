using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIController.instance.GameOverUI();

            GameController.instance.isStarting = false;
            GameController.instance.isPaused = true;
        }
    }
}
