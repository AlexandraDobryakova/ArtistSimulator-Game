using System;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    
    void Start()
    {
        Player.Initialize();
        Game.Initialize();
    }

    void Update()
    { 
        //if(Player.Disease != null)
        //{
        //    if (Game.Time.Days >= GameConstans.DaysUntillGettingIll)
        //    {
        //        Player.Disease = GameConstans.DiseaseCold;
        //        Player.Energy.ValueCoeff = GameConstans.DiseaseCold.decreaseEnergyCoeff;
        //    }
            
        //}
    }  
}
