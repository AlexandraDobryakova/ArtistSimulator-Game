using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Contract : Work, ICloneable
{
    [SerializeField]
    public enum Difficultys
    {
        Easy,
        Normal,
        Hard,
        Crazy
    }

    public Contract(
        string name, 
        int hourWorkload, 
        int contractPrice, 
        Difficultys difficulty,
        GameConstants.Techniques requiredTechnique,
         GameConstants.Genres requiredGenre) :
        base(
            name, 
            GameConstants.Contracts_energyCostPerHour, 
            GameConstants.Contracts_satietyCostPerHour, 
            GameConstants.Contracts_happinessCoef)
    {
        HourWorkload = hourWorkload;
        Difficulty = difficulty;
        ContractPrice = contractPrice;
        this.requiredTechnique = requiredTechnique;
        this.requiredGenre = requiredGenre;
        hoursWorked = 0;
        IsDone = false;
    }

    //TODO: Зависимость от Difficulty
    [SerializeField]
    public GameConstants.Techniques requiredTechnique;
    [SerializeField]
    public GameConstants.Genres requiredGenre;

    public int HourWorkload { get => hourWorkload; private set => hourWorkload = value; }

    public Difficultys Difficulty { get => difficulty; private set => difficulty = value; }
    public int ContractPrice { get => contractPrice; private set => contractPrice = value; }
    public bool IsDone { get => isDone; private set => isDone = value; }

    public override void DoWork(int hoursOfWork)
    {
        Player.Energy.Value -= EnergyCostPerHour * hoursOfWork;
        Player.Satiety.Value -= SatietyCostPerHour * hoursOfWork;
        Player.Happiness.Value += HappinessCoef * hoursOfWork;
        Game.Time.Hours += hoursOfWork;

        hoursWorked += hoursOfWork;

        if (hoursWorked >= HourWorkload)
        {
            IsDone = true;
            Player.ArtSkills.GetSkill(requiredGenre).Xp += GetXPInc(hourWorkload);
            Player.ArtSkills.GetSkill(requiredTechnique).Xp += GetXPInc(hourWorkload);
            Player.Money.Value += ContractPrice;
            Player.CurrentContract = null;
        }
    }

    public int GetDaysLeft() => 10 - (Game.Time.Days - TimeOfGetting.Days);
    public int GetPercentExecution() => (int)(hoursWorked * 1.0 / hourWorkload * 100);

    //TODO
    protected override int GetXPInc(int hoursOfWork)
    {
        return 2 * hoursOfWork;
    }

    public static Contract GetRandomContract()
    {
        var random = new System.Random(Guid.NewGuid().GetHashCode());
        
        var difficult = (Difficultys)random.Next(0, Enum.GetValues(typeof(Difficultys)).Length);
        var randTech = (GameConstants.Techniques)random.Next(0, Enum.GetValues(typeof(GameConstants.Techniques)).Length);
        var randGenre = (GameConstants.Genres)random.Next(0, Enum.GetValues(typeof(GameConstants.Genres)).Length);
        
        switch (difficult)
        {
            case Difficultys.Easy:
                return new Contract("1", random.Next(1, 6),
                    (int)Math.Round(random.Next(100, 600) / 10.0) * 10 / 5, difficult, randTech, randGenre);

           case Difficultys.Normal:
               return new Contract("2", random.Next(12, 12 * 2 + 1), 
                   (int)Math.Round(random.Next(800, 1500) / 100.0) * 100 / 5, difficult, randTech, randGenre);  

           case Difficultys.Hard:
               return new Contract("3", random.Next(12 * 3, 12 * 4 + 1),
                   (int)Math.Round(random.Next(2500, 5000) / 100.0) * 100 / 5, difficult, randTech, randGenre);

           case Difficultys.Crazy:
               return new Contract("4", random.Next(12 * 5, 12 * 6 + 1),
                   (int)Math.Round(random.Next(15000, 20000) / 1000.0) * 1000 / 5, difficult, randTech, randGenre);

           default:
               return new Contract("0", 0, 0, difficult, randTech, randGenre);
        }
    }

    public static Contract[] GetRandomContractsPool()
    {
        var res = new Contract[GameConstants.Contracts_count];
        for (int i = 0; i < GameConstants.Contracts_count; i++)
            res[i] = GetRandomContract();
        return res;
    }

    public object Clone() => MemberwiseClone();

    [SerializeField]
    public GameTime TimeOfGetting;
    [SerializeField]
    private int hourWorkload, hoursWorked, contractPrice;
    [SerializeField]
    private bool isDone;
    [SerializeField]
    private Difficultys difficulty;
   
}