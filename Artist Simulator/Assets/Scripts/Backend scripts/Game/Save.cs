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
        else
            CurrentDiseaseIsNull = true;

        if (Player.CurrentContract != null)
            CurrentContract = Player.CurrentContract;
        else
            CurrentContractIsNull = true;

        if (Player.CurrentJob != null)
            CurrentJob = Player.CurrentJob;
        else
            CurrentJobIsNull = true;


        if (Player.ArtSkills.TechniquesList != null)
            TechniquesList = Player.ArtSkills.TechniquesList;
        if (Player.ArtSkills.GenresList != null)
            GenresList = Player.ArtSkills.GenresList;

        GeneralLvl = Player.ArtSkills.GeneralLvl;

        if (Game.ContractsPool != null)
            ContractsPool = Game.ContractsPool;

        if (!ReferenceEquals(Game.Time, null))
            Time = Game.Time;
        LastChangeContractPoolDay = Game.LastChangeContractPoolDay;
    }

    #region Player
    [SerializeField]
    public Indicator Money = null;
    [SerializeField]
    public Indicator Happiness = null;
    [SerializeField]
    public Indicator Energy = null;
    [SerializeField]
    public Indicator Satiety = null;
    [SerializeField]
    public Disease CurrentDisease = null;
    [SerializeField]
    public Contract CurrentContract = null;
    [SerializeField]
    public Job CurrentJob = null;
    #endregion Player

    #region Skills
    [SerializeField]
    public List<Player.ArtSkills.Skill<GameConstants.Techniques>> TechniquesList = null;
    [SerializeField]
    public List<Player.ArtSkills.Skill<GameConstants.Genres>> GenresList = null;

    [SerializeField]
    public int GeneralLvl;
    #endregion Skills

    #region Game
    [SerializeField]
    public Contract[] ContractsPool = null;
    [SerializeField]
    public GameTime Time = null;
    [SerializeField]
    public int LastChangeContractPoolDay;
    #endregion Game

    [SerializeField]
    public bool CurrentDiseaseIsNull, CurrentContractIsNull, CurrentJobIsNull;

}
