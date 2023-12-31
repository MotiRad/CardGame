using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class CardController : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler , IPointerDownHandler , IPointerUpHandler , IDragHandler
{
    public Card card;
    public Image illustration , image;
    public TextMeshProUGUI cardName, health, manaCost;
    private Transform originalParent;
    
    
    //public GameObject player1Area;
   
    private void Awake() {
        // image is the background of playerHands
        image = GetComponent<Image>();
    }

    private void Start() {
    }

    public void Initialize(Card card , int ownerID, Transform intendedParent)
    {
        CardManager.instance.PlaySFX("StartSound");
        this.card = new Card(card){
            ownerID=ownerID

        };
        
        illustration.sprite=card.illustration;
        cardName.text=card.cardName;
        manaCost.text=card.manaCost.ToString();
        health.text=card.health.ToString();
        originalParent = intendedParent;
        Tweener tween = transform.DOMove(intendedParent.transform.position, 1, true);
        transform.DOScale(1, 0.85f);
        tween.onComplete +=
        () =>
        {
            transform.SetParent(intendedParent);
        };
        if (card.health==0) health.text="" ;
    }
    public void Damage(int amount)
    {
        card.health-= amount;
        health.text=card.health.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    

    public void OnPointerDown(PointerEventData eventData)
    
    {
       
       if(card.cardName == "Alien")
       {
        // صدای رهبر فضایی
        CardManager.instance.PlaySFX("AlienSound");
       }
       else if(card.cardName == "Crocodile")
       {
        // صدای تمساح
        CardManager.instance.PlaySFX("CrocodileSound");

       }
       else if(card.cardName == "Fox")
       {
        // صدای روباه
        CardManager.instance.PlaySFX("FoxSound");
       }
       else
       {
        // صدای دزد دریایی
        CardManager.instance.PlaySFX("PiratesSound");

       }
        
        if(originalParent.name == $"Player{card.ownerID+1}PlayArea" || TurnManager.instance.currentPlayerTurn != card.ownerID)
        {
            
            transform.DOShakeScale(0.35f, 0.5f, 5);
        }
        else
        {
            transform.SetParent(transform.root);
            image.raycastTarget = false;
        }
        

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(originalParent.name == $"Player{card.ownerID+1}PlayArea" || TurnManager.instance.currentPlayerTurn != card.ownerID)
        {

        }
        else{
            image.raycastTarget = true;
            AnalyzePointerUp(eventData);
        }
        
        
    }

    private void AnalyzePointerUp(PointerEventData eventData )
    {
        
        if(eventData.pointerEnter !=null && eventData.pointerEnter.name == $"Player{card.ownerID+1}PlayArea")
        {
           
           
            if(PlayerManager.instance.FindPlayerByID(card.ownerID).mana >= card.manaCost )
            {
               
                PlayCard(eventData.pointerEnter.transform);
                PlayerManager.instance.SpendMana(card.ownerID,card.manaCost);

            }
            else
            {
                transform.DOShakeScale(0.25f, 0.25f, 3);
                ReturnToHand();
            }
        }
        else
        {
            ReturnToHand();
        }
        
    }

    private void PlayCard(Transform playArea)
    {
        if (playArea.childCount == 0)
        {
            transform.SetParent(playArea);
            transform.localPosition = Vector3.zero;
            originalParent = playArea;
            CardManager.instance.PlayCard(this, card.ownerID);
           
        }
        else
        {
            transform.DOShakeScale(0.25f, 0.25f, 3);
            ReturnToHand();
        }

        
       
    }
    public void ReturnToHand()
    {
        Tweener tween = transform.DOMove(originalParent.transform.position, 0.35f, true);
        tween.onComplete +=
        () =>
        {
            transform.SetParent(originalParent);
        };
       transform.SetParent(originalParent);
       transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(transform.parent == originalParent) return;
        transform.position = eventData.position;
    }
}
