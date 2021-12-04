using System;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static class Time
    {
        private static int _hours;

        public static int Hours
        {
            get => _hours;
            set
            {
                if (IsCorrect(value))
                {
                    _hours = value;
                }
            }
        }
    }
    public static void GameOver() { }

    public static Contract[] ContractsPool;

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
        Time.Hours = 0;
        ContractsPool = Contract.GetRandomContractsPool();
    }
}
