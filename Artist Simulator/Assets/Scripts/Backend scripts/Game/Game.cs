using System;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static Contract[] ContractsPool;
    public static GameTime Time;

    public static void GameOver() { }
    public static bool IsCorrect(int value)
    {
        if (value < 0)
            throw new ArgumentException("can't be less than 0");
        return true;
    }
    
    public static bool IsCorrect(string value)
    {
        if (value == null || value == "")
            throw new ArgumentException("can't be empty or null");
        return true;
    }

    public static void Initialize()
    {
        Time = new GameTime();
        ContractsPool = Contract.GetRandomContractsPool();
    }
}
