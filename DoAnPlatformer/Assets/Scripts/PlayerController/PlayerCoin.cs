using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    public AudioClip coinSFX;
    internal int scoreForCoinPickup = 10;
    bool coinCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !coinCollected)
        {
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            coinCollected = true;
            if (gameObject.name.Contains("Coin_Small"))
            {
                MoneyManager.instance.CollectGold(20);
                //Debug.Log(this.name + MoneyManager.instance.gold);
            }
            else if (gameObject.name.Contains("Coin_Copper"))
                MoneyManager.instance.CollectGold(50);
            else if (gameObject.name.Contains("Coin_Golden"))
                MoneyManager.instance.CollectGold(150);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
