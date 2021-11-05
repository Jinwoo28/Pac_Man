using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    private Text text = null;

    private int PlayerCount = 0;
    private void Update()
    {
        text.text = "Coin : " + (100-player.GetComponent<Player>().GetCoinCount()).ToString("D2");
    }

    private void CoinCount()
    {
        PlayerCount = player.GetComponent<Player>().GetCoinCount();
    }

    private void ClearGame()
    {
        if(PlayerCount == 50)
        {
            Debug.Log("게임 클리어");
        }
    }

    private void EndGame()
    {
        if (player.GetComponent<Player>().PlayerLife())
            Debug.Log("게임종료");
    }

}
