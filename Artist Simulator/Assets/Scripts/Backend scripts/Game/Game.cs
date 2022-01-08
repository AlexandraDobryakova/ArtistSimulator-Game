using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Game
{
    public static Contract[] ContractsPool;
    public static GameTime Time;
    
    public static void GameOver() { }
    public static int LastChangeContractPoolDay { get => _lastChangeContractPoolDay; private set { } }
    public static void StartNewGame()
    {
        Game.Initialize();
        Player.Initialize();
    }
    private static void Initialize()
    {
        Time = new GameTime();
        SetNewContractsPool();
    }
    public static void SetNewContractsPool() 
    { 
        ContractsPool = Contract.GetRandomContractsPool();
        _lastChangeContractPoolDay = Time.Days;
    }

    public static void Save()
    {
        _save = new Save();
        PlayerPrefs.SetString(nameof(_save), JsonUtility.ToJson(_save));
        //Debug.Log(JsonUtility.ToJson(_save));
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey(nameof(_save)))
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString(nameof(_save)));

        if (_save.Money != null)
            Player.Money = _save.Money;
        if (_save.Happiness != null)
            Player.Happiness = _save.Happiness;
        if (_save.Energy != null)
            Player.Energy = _save.Energy;
        if (_save.Satiety != null)
            Player.Satiety = _save.Satiety;
        if (_save.CurrentDisease != null)
            Player.CurrentDisease = _save.CurrentDisease;
        if (_save.CurrentContract != null)
            Player.CurrentContract = _save.CurrentContract;
        if (_save.CurrentJob != null)
            Player.CurrentJob = _save.CurrentJob;

        if (_save.TechniquesList != null)
            Player.ArtSkills.TechniquesList = _save.TechniquesList;
        if (_save.GenresList != null)
            Player.ArtSkills.GenresList = _save.GenresList;

        Player.ArtSkills.GeneralLvl = _save.GeneralLvl;

        if (ContractsPool != null)
            ContractsPool = _save.ContractsPool;
        if (!Time.Equals(null))
            Time = _save.Time;

        _lastChangeContractPoolDay = _save.LastChangeContractPoolDay;
    }

    private static int _lastChangeContractPoolDay;
    private static Save _save;
}
