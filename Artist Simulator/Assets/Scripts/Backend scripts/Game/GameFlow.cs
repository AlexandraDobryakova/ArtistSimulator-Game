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


        if (Game.Time.Days - Game.LastChangeContractPoolDay >= 10)
            Game.SetNewContractsPool();

        if (Player.CurrentContract != null && Player.CurrentContract.GetDaysLeft() <= 0)
            Player.CurrentContract = null;
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        Game.Save();
    }
}
