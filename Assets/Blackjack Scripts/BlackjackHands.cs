using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

public class BlackjackHands : UIcontrol
{
    /*[SerializeField] GameObject[] deckCards;*/

    /*private Vector2[] cardPos =
        { new (160,250), new (200, 250), new (240, 250), new (280, 250), new (320, 250), new (360, 250), new (400, 250) };
    private Vector2[] compCardPos =
        { new (710,250), new (750, 250), new (790, 250), new (830, 250), new (870, 250), new (910, 250), new (950, 250) };*/

    private int score = 0;
    private int handCount = 0;
    private int randCard;



    private int[] twoPoints = new int[4] { 1, 2, 3, 4 };
    private int[] threePoints = new int[4] { 5, 6, 7, 8 };
    private int[] fourPoints = new int[4] { 9, 10, 11, 12 };
    private int[] fivePoints = new int[4] { 13, 14, 15, 16 };
    private int[] sixPoints = new int[4] { 17, 18, 19, 20 };
    private int[] sevenPoints = new int[4] { 21, 22, 23, 24 };
    private int[] eightPoints = new int[4] { 25, 26, 27, 28 };
    private int[] ninePoints = new int[4] { 29, 30, 31, 32 };
    private int[] tenPoints = new int[16] { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 };
    private int[] ace = new int[4] { 49, 50, 51, 52 };


    public void Deal()
    {

    }

    public void Hits()
    {

    }
    /*public void Stay()
    {
    }*/

    public void Bust()
    {

    }
    public int[] _twoPoints
    {
        get { return twoPoints; }
    }
    public int[] _threePoints
    {
        get { return threePoints; }
    }
    public int[] _fourPoints
    {
        get { return fourPoints; }
    }
    public int[] _fivePoints
    {
        get { return fivePoints; }
    }
    public int[] _sixPoints
    {
        get { return sixPoints; }
    }
    public int[] _sevenPoints
    {
        get { return sevenPoints; }
    }
    public int[] _eightPoints
    {
        get { return eightPoints; }
    }
    public int[] _ninePoints
    {
        get { return ninePoints; }
    }
    public int[] _tenPoints
    {
        get { return tenPoints; }
    }
    public int[] _ace
    {
        get { return ace; }
    }
    public int _randCard
        {
            get { return randCard; }
            set { randCard = value; }
        }
    public int _score
    {
        get { return score; }
        set { score = value; }
    }
    public int _handCount
    {
        get { return handCount; }
        set { handCount = value; }
    }
}


