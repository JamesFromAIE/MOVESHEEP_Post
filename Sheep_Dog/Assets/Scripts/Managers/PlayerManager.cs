using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance; // VARIABLE FOR SINGLETON

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // SET SINGLETON TO THIS SCRIPT
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int PlayerCurrency { get; private set; }
    public int TotalSheepCaptured { get; private set; }
    public float TotalDogDistance { get; private set; }
    public int LongestStreak { get; private set; }

    public void AddToPlayerCurrency(int value)
    {
        PlayerCurrency += value;
    }

    public void UpdateLongestStreak(int newStreak)
    {
        if (newStreak > LongestStreak) LongestStreak = newStreak;
    }

    public void AddDogDistance(float distance)
    {
        TotalDogDistance += distance / 2.5f; // ADD DOG DISTANCE DIVIDED BY FENCE MESH LENGTH TO WORLD
    }

    public void AddCapturedSheep(int value)
    {
        TotalSheepCaptured += value;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void ClearPlayer()
    {
        SaveSystem.ClearPlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data == null) return;

        PlayerCurrency = data.PlayerCurrency;
        TotalSheepCaptured = data.TotalSheepCaptured;
        TotalDogDistance = data.TotalDogDistance;
        LongestStreak = data.LongestStreak;
    }

}
