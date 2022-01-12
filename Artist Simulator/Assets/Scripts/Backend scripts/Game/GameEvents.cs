using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    
    void Start()
    {
        
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
        //Game.Save();
        //Debug.Log("SAVED BY GAME_EVENTS");
    }
}
