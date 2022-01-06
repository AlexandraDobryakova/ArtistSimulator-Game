using System;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    
    void Start()
    {
        Game.StartNewGame();
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


        if (Game.Time.TotalHours - Game.LastChangeContractPoolHours >= 10)
            Game.SetNewContractsPool();
    }  
}
