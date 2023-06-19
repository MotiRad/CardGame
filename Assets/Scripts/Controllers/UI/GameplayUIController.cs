using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController instance;
    public TextMeshProUGUI currentPlayerTurn;
    public Image currentPlayerTurnImage;
    public Button endTurn;
    public NameChoiceUIController nameChoiceUI;
    private void Awake() {
        instance=this;
        nameChoiceUI.gameObject.SetActive(true);
        SetupButtons();
    }

    private void SetupButtons()
    {
        endTurn.onClick.AddListener(()=>
        {
            TurnManager.instance.EndTurn();
        });
    }

    public void UpdateCurrentPlayerTurn(int ID)
    {

        currentPlayerTurn.gameObject.SetActive(true);
        currentPlayerTurnImage.gameObject.SetActive(true);
        //currentPlayerTurn.text=$"Player{ID+1}`s Turn!";
        currentPlayerTurn.text=$"{PlayerManager.instance.players[ID].playerName}`s Turn!";
        // make it blink
        StartCoroutine(BlinkCurrentPlayerTurn());
    }

    private IEnumerator BlinkCurrentPlayerTurn()
    {
   
       yield return new WaitForSeconds(0.3f);
       currentPlayerTurn.gameObject.SetActive(false);
       currentPlayerTurnImage.gameObject.SetActive(false);
        
        //
        yield return new WaitForSeconds(0.3f);
       currentPlayerTurn.gameObject.SetActive(true);
       currentPlayerTurnImage.gameObject.SetActive(true);

        //
        yield return new WaitForSeconds(0.3f);
       currentPlayerTurn.gameObject.SetActive(false);
       currentPlayerTurnImage.gameObject.SetActive(false);

        //
        yield return new WaitForSeconds(0.3f);
       currentPlayerTurn.gameObject.SetActive(true);
       currentPlayerTurnImage.gameObject.SetActive(true);

        //
        yield return new WaitForSeconds(0.3f);
       currentPlayerTurn.gameObject.SetActive(false);
       currentPlayerTurnImage.gameObject.SetActive(false);
    
    }
}
