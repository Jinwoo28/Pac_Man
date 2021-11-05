using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    private int PlayerCount = 0;
    private void Update()
    {
        
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
