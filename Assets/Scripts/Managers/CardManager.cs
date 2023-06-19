using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public List<Card> cards = new List<Card>();
    public List<int> player1Deck = new List<int>();
    public Transform player1Hand, player2Hand;
    public CardController cardControllerPrefab;
    public List<CardController> player1Cards = new List<CardController>(),
            player2Cards = new List<CardController>(), player1HandCards = new List<CardController>(),
            player2HandCards = new List<CardController>();
   
    public Sound[] sfxSounds;
    public AudioSource sfxSource;
            
            
    private void Awake()
    {
       instance=this;
        
    }

    private void Start()
    {
       
        //GenerateCards();
        //FillDecks();
      
    }

    /*private void FillDecks()
    {
        foreach (Card card in cards)
        {
            player1Deck.Add(new Card(card));
            player1Deck.Add(new Card(card));
        }
        foreach (Card card in cards)
        {
            player2Deck.Add(new Card(card));
            player2Deck.Add(new Card(card));
        }
    }*/

    public void GenerateCards()
    {
        /* foreach(int cardIndex in player1Deck)
         {
             CardController newCard = Instantiate(cardControllerPrefab, player1Hand);
             newCard.transform.localPosition = Vector3.zero;
             newCard.Initialize(cards[cardIndex], 0);
         }*/

        foreach (Card card in cards)
        {
            CardController newCard = Instantiate(cardControllerPrefab, player1Hand.root);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, 0, player1Hand);
            player1HandCards.Add(newCard);
        }
        foreach (Card card in cards)
        {
            CardController newCard = Instantiate(cardControllerPrefab, player2Hand.root);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, 1, player2Hand);
            player2HandCards.Add(newCard);
        }
    }
    public void PlayCard(CardController card, int ID)
    {
        
        
        if (ID == 0)
        {
            player1Cards.Add(card);
            player1HandCards.Remove(card);

        }
        else
        {
            player2Cards.Add(card);
            player2HandCards.Remove(card);
        }


    }

    public void ProcessStartTurn(int ID)
    {

    }
    public void ProcessEndTurn(int ID)
    {

        List<CardController> cards = new List<CardController>();
        List<CardController> enemyCards = new List<CardController>();

        if (ID == 0)
        {
            cards.AddRange(player1Cards);
            enemyCards.AddRange(player2Cards);
        }
        else
        {
            cards.AddRange(player2Cards);
            enemyCards.AddRange(player1Cards);
        }
        if (cards != null && enemyCards != null)
        {
            foreach (CardController cardController in enemyCards)
            {
                if (cardController == null) continue;
                if (CheckTheWinner(enemyCards, cards) == 1)
                {
                    PlayerManager.instance.DamagePlayer(1, cardController.card.health);
                   
                }
                else if (CheckTheWinner(enemyCards, cards) == 2)
                {
                    PlayerManager.instance.DamagePlayer(0, cardController.card.health);

                }
                else
                {
                    GameObject playerUI = GameObject.FindGameObjectWithTag("playArea");
                    Destroy(playerUI.transform.GetChild(0).gameObject);

                    GameObject playerUI2 = GameObject.FindGameObjectWithTag("playArea2");
                    Destroy(playerUI2.transform.GetChild(0).gameObject);


                }


            }


        }




    }


    private int CheckTheWinner(List<CardController> enemycards, List<CardController> cards)
    {
        int cardWins1 = 0;
        if (cards[0].card.health > enemycards[0].card.health)
        {

            //enemycards[0].card.health = cards[0].card.health - enemycards[0].card.health;
            cards[0].card.health -= enemycards[0].card.health;
            cardWins1 = 1;
        }
        else if (cards[0].card.health < enemycards[0].card.health)
        {

            enemycards[0].card.health -= cards[0].card.health;
            cardWins1 = 2;
        }
        else
        {
            cardWins1 = 0;


        }
        Debug.Log(cards[0].card.health);

        return cardWins1;
    }
    
    public void PlaySFX(string name){
        
        Sound s = Array.Find(sfxSounds,x=> x.name == name);
        if (s==null){
            Debug.Log("Source not found");
        }  
        else{
            sfxSource.PlayOneShot(s.clip);
        }
        
    }
    

   /* public void ToggleSFX(){
        sfxSource.mute=!sfxSource.mute;
    }*/
   
    /*public void SFXVolume(float volume){
        sfxSource.volume=volume;
        // AudioListener.volume=volume;

    }*/

    
   
}
