using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Keey : MonoBehaviour
{
    int gameCount = 0;
    private bool shuffleTurn = true;
    private bool selectTurn = false;
    private bool randomTurn = true;


    string[] mark = new string[] { "♠", "♥", "♦", "♣" };
    string[] rank = new string[] { "Ａ", "２", "３", "４", "５", "６", "７", "８", "９", "10", "Ｊ", "Ｑ", "Ｋ" };
    string[,] cards = new string[4, 13];

    //int mark1, mark2, mark3, mark4, mark5;
    int rank1, rank2, rank3, rank4, rank5;


    void Start()
    {
        print("Game start!  y/n");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                cards[i, j] = mark[i] + rank[j];
                print(cards[i, j]);
            }
        }
    }

    void Update()
    {
        gameCount = 1;
        //shuffleTurn = true;
        if (shuffleTurn)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Shuffle();//シャッフルして表示
                //ShowCards();
                shuffleTurn = false;
            }
        }
        if (selectTurn)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))//１番目のカードを交換
            {
                print("222222");
                SecondShuffle();


                selectTurn = false;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {

            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {

            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {

            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                print("CCCCC");
                selectTurn = false;
            }
        }
    }
    private void SecondShowCards()//二度目：確定のカードを表示
    {
        //print("[" + cards[rank1] + "],["
              //+ cards[rank2] + "],["
              //+ cards[rank3] + "], ["
              //+ cards[rank4] + "],["
              //+ cards[rank5] + "]");
        //Judge();ここで呼びたい
        Judge jd = GetComponent<Judge>();
        jd.Judgement(mark, rank);
        print("判定");
    }

    //private void Judge()//役の判定
    //{
    //    throw new NotImplementedException();
    //}

    private void Random1()//１番目のカードをランダムにする
    {
        //mark1 = Random.Range(0, 3);
        //rank1 = Random.Range(0, 12);
    }

    private void SecondShuffle() //１番目のカードをチェンジ
    {
        print("!!!!!");
        if (randomTurn)
        {
            Random1();
            SecondShowCards();
        }
        randomTurn = false;
    }

    private void Shuffle()
    {
        rank1 = Random.Range(0, 52);
        while (true)
        {
            rank2 = Random.Range(0, 52);
            if (rank2 != rank1) break;
        }
        while (true)
        {
            rank3 = Random.Range(0, 52);
            if (rank3 != rank1 && rank3 != rank2) break;
        }
        while (true)
        {
            rank4 = Random.Range(0, 52);
            if (rank4 != rank1 && rank4 != rank2 && rank4 != rank3) break;
        }
        while (true)
        {
            rank5 = Random.Range(0, 52);
            if (rank5 != rank1 && rank5 != rank2 && rank5 != rank3 && rank5 != rank4) break;
        }


    }

    //private void ShowCards()//1回目のカードを表示
    //{
    //    print("[" + cards[rank1] + "],["
    //          + cards[rank2] + "],["
    //          + cards[rank3] + "], ["
    //          + cards[rank4] + "],["
    //          + cards[rank5] + "]");

    //    print("何番目のカードを入れ替えますか？　1/2/3/4/5");
    //    selectTurn = true;
    //}
}