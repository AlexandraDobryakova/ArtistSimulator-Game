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
        PlayerPrefs.DeleteAll();

        //Debug.Log(nameof(StartNewGame));
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
        Debug.Log($"SAVE\n{JsonUtility.ToJson(_save)}");
    }

    public static void Load()
    {
        if (HasSave())
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString(nameof(_save)));
            Debug.Log($"LOAD");

            Player.Initialize();
            Game.Initialize();
            if (_save.Money != null)
                Player.Money = _save.Money;
            if (_save.Happiness != null)
                Player.Happiness = _save.Happiness;
            if (_save.Energy != null)
                Player.Energy = _save.Energy;
            if (_save.Satiety != null)
                Player.Satiety = _save.Satiety;

            Player.CurrentDisease = _save.CurrentDiseaseIsNull ? null : _save.CurrentDisease;
            Player.CurrentContract = _save.CurrentContractIsNull ? null : _save.CurrentContract;
            Player.CurrentJob = _save.CurrentJobIsNull ? null : _save.CurrentJob;

            if (_save.TechniquesList != null)
                Player.ArtSkills.TechniquesList = _save.TechniquesList;
            if (_save.GenresList != null)
                Player.ArtSkills.GenresList = _save.GenresList;

            Player.ArtSkills.GeneralLvl = _save.GeneralLvl;

            if (_save.ContractsPool != null)
                Game.ContractsPool = _save.ContractsPool;

            if (!ReferenceEquals(_save.Time, null))
                Game.Time = _save.Time;

            _lastChangeContractPoolDay = _save.LastChangeContractPoolDay;


        }

    }

    public static bool HasSave() => PlayerPrefs.HasKey(nameof(_save));

    private static int _lastChangeContractPoolDay;
    private static Save _save;
}
