using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;

    public int currentCoin;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AddCoin(0);
    }

    public void AddCoin(int coinAmount)
    {
        currentCoin += coinAmount;
        // Update UI
        UIController.instance.UpdateUIText(currentCoin.ToString());

        int totalCoin = PlayerPrefs.GetInt("total");
        totalCoin += coinAmount;

        PlayerPrefs.SetInt("total", totalCoin);

        PlayerPrefs.SetInt("coin", currentCoin);
    }
}
