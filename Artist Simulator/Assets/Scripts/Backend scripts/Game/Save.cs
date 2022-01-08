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

        if (Player.ArtSkills.TechniquesList != null)
            TechniquesList = Player.ArtSkills.TechniquesList;
        if (Player.ArtSkills.GenresList != null)
            GenresList = Player.ArtSkills.GenresList;

        GeneralLvl = Player.ArtSkills.GeneralLvl;

        if (Game.ContractsPool != null)
            ContractsPool = Game.ContractsPool;
        if (!Game.Time.Equals(null))
            Time = Game.Time;
        LastChangeContractPoolDay = Game.LastChangeContractPoolDay;

    }

    #region Player
    [SerializeField]
    public Indicator Money;
    [SerializeField]
    public Indicator Happiness;
    [SerializeField]
    public Indicator Energy;
    [SerializeField]
    public Indicator Satiety;
    [SerializeField]
    public Disease CurrentDisease;
    [SerializeField]
    public Contract CurrentContract;
    [SerializeField]
    public Job CurrentJob;
    #endregion Player

    #region Skills
    [SerializeField]
    public List<Player.ArtSkills.Skill<GameConstants.Techniques>> TechniquesList;
    [SerializeField]
    public List<Player.ArtSkills.Skill<GameConstants.Genres>> GenresList;

    [SerializeField]
    public int GeneralLvl;
    #endregion Skills

    #region Game
    [SerializeField]
    public Contract[] ContractsPool;
    [SerializeField]
    public GameTime Time;
    [SerializeField]
    public int LastChangeContractPoolDay;
    #endregion Game

}
