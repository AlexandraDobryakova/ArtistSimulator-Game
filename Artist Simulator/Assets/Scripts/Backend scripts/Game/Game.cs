using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static Contract[] ContractsPool;
    public static GameTime Time;

    public static void GameOver() { }
    public static int LastChangeContractPoolDay { get => _lastChangeContractPoolDay; private set { } }
    public static bool IsCorrect(int value)
    {
        if (value < 0)
            throw new ArgumentException("can't be less than 0");
        return true;
    }

    public static void StartNewGame()
    {
        Game.Initialize();
        Player.Initialize();
    }
    
    public static bool IsCorrect(string value)
    {
        if (value == null || value == "")
            throw new ArgumentException("can't be empty or null");
        return true;
    }

    private static void Initialize()
    {
        Time = new GameTime();
        SetNewContractsPool();
    }

    public static void SetNewContractsPool() 
    { 
        ContractsPool = Contract.GetRandomContractsPool();
        _lastChangeContractPoolDay = Time.Days;
    }

    private static int _lastChangeContractPoolDay;

}
