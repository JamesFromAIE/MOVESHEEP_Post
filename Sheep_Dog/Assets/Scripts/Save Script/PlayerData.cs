using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int PlayerCurrency;
    public int TotalSheepCaptured;
    public float TotalDogDistance;
    public int LongestStreak;

    public PlayerData (PlayerManager player)
    {
        PlayerCurrency = player.PlayerCurrency;
        TotalSheepCaptured = player.TotalSheepCaptured;
        TotalDogDistance = player.TotalDogDistance;
        LongestStreak = player.LongestStreak;
    }

    public void ClearData ()
    {
        PlayerCurrency = 0;
        TotalSheepCaptured = 0;
        TotalDogDistance = 0;
        LongestStreak = 0;
    }

}
