using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public Save()
    {
        if (Player.Money != null)
            Money = Player.Money;
        if (Player.Happiness != null)
            Happiness = Player.Happiness;
        if (Player.Energy != null)
            Energy = Player.Energy;
        if (Player.Satiety != null)
            Satiety = Player.Satiety;
        if (Player.CurrentDisease != null)
            CurrentDisease = Player.CurrentDisease;
        if (Player.CurrentContract != null)
            CurrentContract = Player.CurrentContract;
        if (Player.CurrentJob != null)
            CurrentJob = Player.CurrentJob;

        if (Player.ArtSkills.TechniquesDict != null)
            TechniquesDict = Player.ArtSkills.TechniquesDict;
        if (Player.ArtSkills.GenresDict != null)
            GenresDict = Player.ArtSkills.GenresDict;
        GeneralLvl = Player.ArtSkills.GeneralLvl;

        if (Game.ContractsPool != null)
            ContractsPool = Game.ContractsPool;
        if (Game.Time != null)
            Time = Game.Time;
        LastChangeContractPoolDay = Game.LastChangeContractPoolDay;
    }

    #region Player
    public Indicator Money;
    public Indicator Happiness;
    public Indicator Energy;
    public Indicator Satiety;
    public Disease CurrentDisease;
    public Contract CurrentContract;
    public Job CurrentJob;
    #endregion Player

    #region Skills
    public Dictionary<GameConstants.Techniques, Player.ArtSkills.Skill<GameConstants.Techniques>> TechniquesDict;
    public Dictionary<GameConstants.Genres, Player.ArtSkills.Skill<GameConstants.Genres>> GenresDict;
    public int GeneralLvl;
    #endregion Skills

    #region Game
    public Contract[] ContractsPool;
    public GameTime Time;
    public int LastChangeContractPoolDay;
    #endregion Game

}
