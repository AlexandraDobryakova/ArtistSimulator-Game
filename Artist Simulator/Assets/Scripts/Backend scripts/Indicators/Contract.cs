using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : Work
{
    public enum Difficultys
    {
        Easy,
        Normal,
        Hard,
        Crazy
    }


    public Contract(string name, int hourWorkload, int contractPrice, Difficultys difficulty,
        Player.ArtSkills.Techniques requiredTechnique, Player.ArtSkills.Genres requiredGenre) :
        base(name, energyCostPerHour, satietyCostPerHour, happinessCoef)
    {
        HourWorkload = hourWorkload;
        Difficulty = difficulty;
        ContractPrice = contractPrice;
        this.requiredTechnique = requiredTechnique;
        this.requiredGenre = requiredGenre;
        hoursWorked = 0;
        IsDone = false;
    }

    public int HourWorkload { get => hourWorkload; private set => hourWorkload = value; }

    public Difficultys Difficulty { get => difficulty; private set => difficulty = value; }
    public int ContractPrice { get => contractPrice; private set => contractPrice = value; }
    public bool IsDone { get => isDone; private set => isDone = value; }

    public override void DoWork(int hoursOfWork)
    {
        Player.Energy.Value -= EnergyCostPerHour * hoursOfWork;
        Player.Satiety.Value -= SatietyCostPerHour * hoursOfWork;
        Player.Happiness.Value += HappinessCoef * hoursOfWork;

        hoursWorked += hoursOfWork;
        if (hoursWorked >= HourWorkload)
        {
            IsDone = true;
            Player.ArtSkills.GetSkill(requiredGenre).Xp += GetXPInc();
            Player.ArtSkills.GetSkill(requiredTechnique).Xp += GetXPInc();
            Player.Money.Value += ContractPrice;
        }
    }

    public override int GetXPInc()
    {
        throw new System.NotImplementedException();
    }

    private static readonly int energyCostPerHour, satietyCostPerHour, happinessCoef;
    private int hourWorkload, hoursWorked, contractPrice;
    private bool isDone;
    private Difficultys difficulty;
    private Player.ArtSkills.Techniques requiredTechnique;
    
    private Player.ArtSkills.Genres requiredGenre;
}