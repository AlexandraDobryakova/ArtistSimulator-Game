//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Satiety : Indicator<int>
//{
//    public Satiety(int startValue, string dimension) : base(startValue, dimension) { }
//    public override int Value
//    {
//        get => _value;
//        set
//        {
//            if (value <= 0)
//            {
//                GameControls.GameOver();
//                return;
//            }
//            _value = value;
//        }
//    }
//}