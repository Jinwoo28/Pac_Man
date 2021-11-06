using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverUi = null;

    [SerializeField]
    private GameObject player = null;

    [SerializeField]
    private Text text = null;

    [SerializeField]
    private Transform AmountCoin = null;

    [SerializeField]
    private RawImage FullMiniMap = null;
    [SerializeField]
    private GameObject SmallMiniMap = null;

    private int GoalCount = 0;
    private int Count = 0;

    private bool minimapchange = true;


 

    private void Awake()
    {
        foreach(Transform child in AmountCoin)
        {
            GoalCount++;
        }

    }

    private void Update()
    {
        text.text = "Coin : " + Count.ToString("D2");

        PlayerDie();

        MinimapChange1();
        
        SetCoinCount();



        if (Input.GetMouseButtonDown(0)&& !player.GetComponent<Player>().GetPlayerDie()) 
        {
            minimapchange = !minimapchange;
        }


    }

    private void SetCoinCount()
    {
        Count = GoalCount - player.GetComponent<Player>().GetCoinCount();
        if(Count == 0) { SceneManager.LoadScene(2); }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
        player.GetComponent<Player>().PlayerRevive();
        Time.timeScale = 1;
    }


    public void PlayerDie()
    {
        if (player.GetComponent<Player>().GetPlayerDie())
        {
            GameOverUi.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MinimapChange1()
    {
        FullMiniMap.enabled = minimapchange;
        SmallMiniMap.SetActive(!minimapchange);
    }





}
