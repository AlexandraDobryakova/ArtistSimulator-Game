using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTime
{
    private int _hours, _totalHours, _days;

    public GameTime()
    {
        Hours = 0;
        _totalHours = 0;
        _days = 0;
    }
    public GameTime(int hours, int days)
    {
        Hours = hours;
        _totalHours += 24 * days;
        _days = days;
    }

    public int Hours
    {
        get => _hours;
        set
        {
            if (Game.IsCorrect(value))
            {
                if (value >= _hours)
                {
                    _totalHours += value - _hours;
                    _hours = value >= 24 ? value % 24 : value;

                    if (value >= 24)
                    {
                        _hours = value % 24;
                        _days += value / 24;
                    }
                    else
                        _hours= value;
                }
                else
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(value)} can't be reduced.");
            }
        }
    }

    public int Days { get => _days; private set { } }

    public static GameTime operator +(GameTime t1, GameTime t2) =>
        new GameTime(t1._hours + t2._hours, t1._days + t2._days);

    //public static Time operator - (Time t1, Time t2) =>
    //    new (t1._hours + t2._hours, t1._days + t2._days);
    public static bool operator ==(GameTime t1, GameTime t2) =>
        t1._hours == t2._hours && t1._days == t2._days;
    public static bool operator !=(GameTime t1, GameTime t2) => !(t1 == t2);
    public static bool operator >(GameTime t1, GameTime t2) =>
        t1._days > t2._days || t1._days == t2._days && t1._hours > t2._hours;
    public static bool operator <(GameTime t1, GameTime t2) => !(t1 > t2) && t1 != t2;
    public static bool operator >=(GameTime t1, GameTime t2) => !(t1 < t2);
    public static bool operator <=(GameTime t1, GameTime t2) => !(t1 > t2);
}
