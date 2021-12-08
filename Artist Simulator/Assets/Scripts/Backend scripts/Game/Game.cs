using System;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static class Time
    {
        private static int _hour, _totalHours;

        public static int Hour 
        { 
            get => _hour;
            set
            {
                if (IsCorrect(value))
                {
                    if(value >= _hour)
                    {
                        _totalHours += value - _hour;
                        _hour = value >= 24 ? value % 24 : value;
                    } 
                    else
                        throw new ArgumentOutOfRangeException(
                            $"{nameof(value)} can't be reduced.");
                }
            }
        }

        public static int Day { get => _totalHours / 24; private set { } }
    }


    public static Contract[] ContractsPool;

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
        Time.Hour = 0;
        ContractsPool = Contract.GetRandomContractsPool();
    }
}
