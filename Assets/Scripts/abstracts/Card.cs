using UnityEngine;
[System.Serializable]
public class Card 
{
  //for data
  public string cardName;
  public int health, manaCost, ownerID;
  public Sprite illustration;
  public Card(){

  }
  public Card(Card card){

    cardName = card.cardName;
    health = card.health;
    manaCost=card.manaCost;
    illustration=card.illustration;
  }

}
