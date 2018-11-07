using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //`ClassName.EnumName`がsuitの型名
    public SuitEnum.Suit suit;
    public int rank;

    //コンストラクター
    public Card(SuitEnum.Suit _suit, int _rank)
    {
        this.suit = _suit;
        this.rank = _rank;
    }


}




//public void ShowCard(Image image)
//{
//    //image.sprite = //欲しい画像を入れる
//}

////カードを捨てたら音を鳴らす
//public void RingDustSound()
//{

//}

//カードの強さを比較したい
//public bool IsHigh(Card card)
//{
//    if (this.rank > card.rank)
//        return true;
//    if (this.rank < card.rank)
//        return false;
//    if (this.rank == card.rank)
//    {
//        if ((int)this.mark > (int)card.mark)
//            return true;
//        else
//            return false;
//    }
//}
