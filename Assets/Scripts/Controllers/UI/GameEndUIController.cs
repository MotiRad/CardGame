using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class GameEndUIController : MonoBehaviour
{

    public TextMeshProUGUI winnerName;
    public Button restart;
    public Image WinnerHeroPortrait , player0Portrait, player1Portrait;
    

    private void Awake() 
    {
        SetupButtons();    
    }

    private void SetupButtons()
    {
        restart.onClick.AddListener(() =>
        {
            RestartMatch();
        });

       /* quit.onClick.AddListener(() =>
        {
            QuitGame();
        });*/
    }

    private void RestartMatch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    private void QuitGame()
    {
        /*if(Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }*/
    }

    public void Initialize(Player winner){

        winnerName.text = $"{winner.playerName} has won!";
        if(winner.ID == 0){
            WinnerHeroPortrait.sprite = player0Portrait.sprite;
           
       }
       else{
            WinnerHeroPortrait.sprite = player1Portrait.sprite;
            
       }
        
    }
}
