using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static Indicator Money;
    public static Indicator Happiness;
    public static Indicator Energy;
    public static Indicator Satiety;

    public static void Initialize()
    {
        Money = new Indicator(5000, 999999, "ð");
        Happiness = new Indicator(100, 100, "%");
        Energy = new Indicator(100, 100, "%");
        Satiety = new Indicator(100, 100, "%");
    }
}
