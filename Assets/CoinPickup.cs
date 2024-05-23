using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinPickup : MonoBehaviour
{

    private SpriteRenderer _CoinSpriteRenderer;
    private void Awake()
    {
        _CoinSpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && _CoinSpriteRenderer.enabled == true)
        {
            GameObject[] TotalCoins = GameObject.FindGameObjectsWithTag("Coin");
            if (TotalCoins.Length - 1 > 0)
            {
                CoinCounter.Instance.IncreaseCoinCount();
                Destroy(gameObject);
            }
            else
            {
                CoinCounter.Instance.IncreaseCoinCount();
                Destroy(gameObject);
                if (SceneManager.GetActiveScene().name == "Level 1")
                {
                    SceneManager.LoadScene("Level 2");
                }
                if (SceneManager.GetActiveScene().name == "Level 2")
                {
                    SceneManager.LoadScene("Level 3");
                }
            }
        }
    }
}
