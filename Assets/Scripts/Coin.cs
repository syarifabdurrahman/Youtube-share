using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool canAdd;

    private void Awake()
    {
        canAdd = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Colllect");

            if (canAdd)
            {
                // Effect

                CoinController.instance.AddCoin(5);

                canAdd = false;
            }

            Destroy(gameObject, .3f);
        }
    }
}
