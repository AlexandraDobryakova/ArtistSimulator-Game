using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Contract : Work
{
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
        Player.ArtSkills.Techniques requiredTechnique, 
        Player.ArtSkills.Genres requiredGenre) :
        base(
            name, 
            GameConstans.Contracts_energyCostPerHour, 
            GameConstans.Contracts_satietyCostPerHour, 
            GameConstans.Contracts_happinessCoef)
    {
        HourWorkload = hourWorkload;
        Difficulty = difficulty;
        ContractPrice = contractPrice;
        this.requiredTechnique = requiredTechnique;
        this.requiredGenre = requiredGenre;
        hoursWorked = 0;
        IsDone = false;
    }

    //TODO: ����������� �� Difficulty
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

    //TODO
    public override int GetXPInc(int hoursOfWork)
    {
        return 2 * hoursOfWork;
    }

    public int GetPercentExecution() => (hoursWorked / HourWorkload) * 100;

    public static Contract GetRandomContract()
    {
        var random = new System.Random();
        var difficult = (Difficultys)random.Next(0, Enum.GetValues(typeof(Difficultys)).Length);
        var randTech = (Player.ArtSkills.Techniques)random.Next(0, Enum.GetValues(typeof(Player.ArtSkills.Techniques)).Length);
        var randGenre = (Player.ArtSkills.Genres)random.Next(0, Enum.GetValues(typeof(Player.ArtSkills.Genres)).Length);
        
        switch (difficult)
        {
            case Difficultys.Easy:
                return new Contract("1", random.Next(1, 6),
                    (int)Math.Round(random.Next(100, 600) / 10.0) * 10, difficult, randTech, randGenre);

           case Difficultys.Normal:
               return new Contract("2", random.Next(12, 12 * 2 + 1), 
                   (int)Math.Round(random.Next(800, 1500) / 100.0) * 100, difficult, randTech, randGenre);  

           case Difficultys.Hard:
               return new Contract("3", random.Next(12 * 3, 12 * 4 + 1),
                   (int)Math.Round(random.Next(2500, 5000) / 100.0) * 100, difficult, randTech, randGenre);

           case Difficultys.Crazy:
               return new Contract("4", random.Next(12 * 5, 12 * 6 + 1),
                   (int)Math.Round(random.Next(15000, 20000) / 1000.0) * 1000, difficult, randTech, randGenre);

           default:
               return new Contract("0", 0, 0, difficult, randTech, randGenre);
        }
    }

    public static Contract[] GetRandomContractsPool()
    {
        var res = new Contract[GameConstans.Contracts_count];
        for (int i = 0; i < GameConstans.Contracts_count; i++)
            res[i] = GetRandomContract();
        return res;
    }

    private int hourWorkload, hoursWorked, contractPrice;
    private bool isDone;
    private Difficultys difficulty;
    private Player.ArtSkills.Techniques requiredTechnique;
    
    private Player.ArtSkills.Genres requiredGenre;
}