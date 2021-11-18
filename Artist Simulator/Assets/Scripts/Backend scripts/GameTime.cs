using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameTime
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

    //public static GameTime GlobalTime 
    //{ 
    //    get => _globalTime;
    //    private set { }
    //}

    //public GameTime() { }

    //public GameTime(int hours)
    //{
    //    Hour = hours;
    //}

    //public GameTime(int hours, int days)
    //{
    //    Hour = hours;
    //    Day = days;
    //}

    ////public GameTime(int hours, int days, int weeks)
    ////{
    ////    Hour = hours;
    ////    Day = days;
    ////    Week = weeks;
    ////}
    //public int Hour
    //{
    //    get => _hour;
    //    set
    //    {
    //        if (IsCorrect(value))
    //        {
    //            if (value >= 24)
    //            {
    //                _hour = value - value % 24;
    //                Day += value / 24;
    //            }
    //            else
    //                _hour = value;
    //        }
    //    }
    //}

    //public int Day 
    //{ 
    //    get => _day;
    //    set
    //    {
    //        if (IsCorrect(value))
    //        {
    //            _day = value;
    //            //if (value >= 30)
    //            //{
    //            //    _day = value - value / 30;
    //            //    Week += value / 30;
    //            //}
    //            //else
    //            //    _day = value;
    //        }
    //    }
    //}

    ////public int Week
    ////{ 
    ////    get => _week;
    ////    set
    ////    {
    ////        if (IsCorrect(value))
    ////            _week = value;
    ////    }
    ////}

    //public static GameTime operator +(GameTime t1, GameTime t2) => 
    //    new (t1.Hour + t2.Hour, t1.Day + t2.Day/*, t1.Week + t2.Week*/);


    //private static GameTime _globalTime;
    //private int _hour = 0, _day = 0/*, _week = 0*/;
    private static bool IsCorrect(int value)
    {
        if (value < 0)
            throw new ArgumentException("");
        return true;
    }
}
