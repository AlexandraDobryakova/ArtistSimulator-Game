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

        if (Game.Time.Days - Game.LastChangeContractPoolDay >= 10)
            Game.SetNewContractsPool();

        if (Player.CurrentContract != null && Player.CurrentContract.GetDaysLeft() <= 0)
            Player.CurrentContract = null;

        if (Player.CurrentDisease != null && Game.Time.Days - Player.CurrentDisease.TimeOfGettingIll.Days >= Player.CurrentDisease.TimeToHeal.Days)
        {
            Player.GetWell();
        }


        if (Game.Time.Days == 2 && Player.CurrentDisease == null)
        {
            Player.SetIll(GameConstants.DiseaseCold);
        }
    }
}
