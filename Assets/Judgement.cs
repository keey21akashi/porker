using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour {

    public List<Card> playerCards = new List<Card>();

    public void Judge(List<Card> _playerCards){
        this.playerCards = _playerCards;

    }
}
