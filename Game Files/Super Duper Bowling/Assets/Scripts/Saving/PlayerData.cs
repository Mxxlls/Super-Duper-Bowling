using System;
using UnityEngine;

[Serializable]
public class PlayerSaveData
{
    public float bestTime; // legacy
    public float bestTimeOne;
    public float bestTimeTwo;
    public float bestTimeThree;
    public float bestTimeFour;
    public float bestTimeFive;
    public float bestTimeSix;

    public PlayerSaveData(float bestTime, float bestTimeOne, float bestTimeTwo, float bestTimeThree, float bestTimeFour, float bestTimeFive, float bestTimeSix)
    {
        this.bestTime = bestTime;
        this.bestTimeOne = bestTimeOne;
        this.bestTimeTwo = bestTimeTwo;
        this.bestTimeThree = bestTimeThree;
        this.bestTimeFour = bestTimeFour;
        this.bestTimeFive = bestTimeFive;
        this.bestTimeSix = bestTimeSix;

    }
}