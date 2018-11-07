using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


//ここはゲームのロジックのみを作る
//カードの配布、シャッフル、役の判定、viewへの表示を行う。
public class GameSystem : MonoBehaviour
{

    public Image[] images; //UnityのUI上のImageの場所
    //手札
    public List<Card> playerCards = new List<Card>();
    //山札
    public List<Card> allCards = new List<Card>();
    //廃棄したカード
    public List<Card> disCards = new List<Card>();

    string result;


    public void Init()
    {
        //allCards に全てのCardを格納
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Card card = new Card((SuitEnum.Suit)Enum.ToObject(typeof(SuitEnum.Suit), j),
                                     (RankEnum.Rank)Enum.ToObject(typeof(RankEnum.Rank), i));
                allCards.Add(card);
                print(j + "," + i);
                //`(SuitEnum.Suit)Enum.ToObject(typeof(SuitEnum.Suit), j)`でSuitをindexから呼び出す
            }
        }
    }
    
    public Card GetNewCard()
    {
        //山札に残ってるものから乱数を取る
        int randomNum = Random.Range(0, allCards.Count);
        //新しくカードを生成
        Card card = allCards[randomNum];
        //生成したカードを山札から引く
        allCards.Remove(card);
        return card;
    }
    private static void Print(List<Card> cards)
    {
        foreach(Card c in cards){
            print(c.suit + "," + c.rank);
        }
        
    }
    
    private void Judge()
    {
        Judgement jd = GetComponent<Judgement>();
        result = jd.Judge(playerCards);
        print(result);
    }

    public void Start()
    {
        Init(); //①

        //5枚引く
        for (int i = 0; i < 5; i++){
            Card card = GetNewCard(); //②
            playerCards.Add(card); //③
        }
        Print(playerCards);


        //交換するカードを選択して捨てる (n回<6)
        //Select(card);

        //捨てた分新しいカードを引く
        /*
         * Card newCard = GetNewCard(); //⑥
        playerCards.Add(newCard); //⑦
        Print(playerCards);
        */
        //役を判定する
        Judge();

        //int index = 0;
        //foreach (Card card in playerCards)
        //{
        //    card.ShowCard(images[index]);
        //    index++;
        //}

        ////特定のカードを捨てる
        //playerCards[3].RingDustSound();
        //playerCards.Remove(3);

    }

    private void Select(Card card)
    {
        playerCards.Remove(card);//④
        //廃棄カードリストに追加
        disCards.Add(card); //⑤
    }
}