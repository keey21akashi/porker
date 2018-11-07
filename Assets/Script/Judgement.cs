using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    const string Ranks = "A23456789TJQKA";
    const string Suits = "SDHC";

    public string Judge(List<Card> playerCards)
    {

        if (IsRoyalStraightFlush(playerCards)) return "Royal straight flush";
        else if (IsStraightFlush(playerCards)) return "Straight flush";
        else if (Is4cards(playerCards)) return "Four of a kind";
        else if (IsFullHouse(playerCards)) return "Full house";
        else if (IsFlush(playerCards)) return "Flush";
        else if (IsStraight(playerCards)) return "Straight";
        else if (Is3Cards(playerCards)) return "Three of a kind";
        else if (Is2Pair(playerCards)) return "Two pair";
        else if (Is1Pair(playerCards)) return "One pair";
        else return "No pair";
    }

    static bool IsRoyalStraightFlush(List<Card> cards)
    {
        bool isR = false; 
        if (IsFlush(cards) && IsStraight(cards))
        {

                for (int i = 2; i <= 9; i++)
                {//2～9までの数字が含まれていたらNG
                    
                    cards.ForEach((Card obj) =>
                    {
                        if(obj.rank.Equals(i)){
                            isR = false;
                            //breakしたい
                        } 
                    });
                }
            isR = true;
            return isR;
        }
        return isR;
    }

    static bool IsStraightFlush(List<Card> cards)
    {
        return IsFlush(cards) && IsStraight(cards);
    }

    static bool Is4cards(List<Card> cards)
    {
        return IsAnyCards(cards, 4);
    }

    static bool IsFullHouse(List<Card> cards)
    {
        return Is3Cards(cards) && Is1Pair(cards);
    }

    static bool IsFlush(List<Card> cards)
    {
        foreach (char suit in Suits.ToCharArray())
        {//あるスーツの文字を切り取って
            if (cards.Length - cards.Replace(suit.ToString(), "").Length == 5) return true;
            //5文字減ったら5枚全て同じスーツ
        }
        return false;
    }

    static bool IsStraight(List<Card> cards)
    {
        List<string> rankListInCards = new List<string>();//カードのランクのみ
                                                          //ランク切り出し
        for (int i = 1; i <= 9; i = i + 2)
        {
            rankListInCards.Add(cards[i].ToString());
        }
        //並び替え
        rankListInCards.Sort(cardRankSort);
        //ソート済みカードリスト作成
        string sortedCards = "";
        foreach (string card in rankListInCards)
        {
            sortedCards += card;
        }
        //判定
        if (Ranks.Contains(sortedCards)) return true;
        if (sortedCards[0] == 'A')
        {//先頭がAなら
         //末尾に移してもう一度判定
            if (Ranks.Contains(sortedCards.Remove(0, 1).PadRight(5, 'A'))) return true;
        }
        return false;
    }

    static bool Is3Cards(List<Card> cards)
    {
        return IsAnyCards(cards, 3);
    }

    static bool Is2Pair(List<Card> cards)
    {
        foreach (char Rank in Ranks.ToCharArray())
        {
            if (cards.Length - cards.Replace(Rank.ToString(), "").Length == 2)
            {//One pairだったら
                return Is1Pair(cards.Replace(Rank.ToString(), ""));//One pairが2回でTwo pair
            }
        }
        return false;
    }

    static bool Is1Pair(List<Card> cards)
    {
        return IsAnyCards(cards, 2);
    }

    //あるカードがany枚含まれているかどうかを判定
    static bool IsAnyCards(List<Card> cards, int any)
    {
        foreach (char Rank in Ranks.ToCharArray())
        {
            if (cards.Length - cards.Replace(Rank.ToString(), "").Length == any) return true;
        }
        return false;
    }

    static int cardRankSort(List<Card> x, string y)
    {
        return Ranks.IndexOf(x) - Ranks.IndexOf(y);
    }
}
