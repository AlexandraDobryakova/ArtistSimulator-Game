using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

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

        if (_save.TechniquesDict != null)
            Player.ArtSkills.TechniquesDict = _save.TechniquesDict;
        if (_save.GenresDict != null)
            Player.ArtSkills.GenresDict = _save.GenresDict;

        Player.ArtSkills.GeneralLvl = _save.GeneralLvl;

        if (ContractsPool != null)
            ContractsPool = _save.ContractsPool;
        if (Time != null)
            Time = _save.Time;

        _lastChangeContractPoolDay = _save.LastChangeContractPoolDay;
    }

    private static int _lastChangeContractPoolDay;
    private static Save _save;
    //public static bool IsCorrect(string value)
    //{
    //    if (value == null || value == "")
    //        throw new ArgumentException("can't be empty or null");
    //    return true;
    //}

    //public static bool IsCorrect(int value)
    //{
    //    if (value < 0)
    //        throw new ArgumentException("can't be less than 0");
    //    return true;
    //}
}
