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
        //IsDone = false;
    }

    //TODO: Зависимость от Difficulty
    public int HourWorkload { get => hourWorkload; private set => hourWorkload = value; }

    public Difficultys Difficulty { get => difficulty; private set => difficulty = value; }
    public int ContractPrice { get => contractPrice; private set => contractPrice = value; }
    //public bool IsDone { get => isDone; private set => isDone = value; }

    public override void DoWork(int hoursOfWork)
    {
        Player.Energy.Value -= EnergyCostPerHour * hoursOfWork;
        Player.Satiety.Value -= SatietyCostPerHour * hoursOfWork;
        Player.Happiness.Value += HappinessCoef * hoursOfWork;
        Game.Time.Hours += hoursOfWork;

        hoursWorked += hoursOfWork;
        if (hoursWorked >= HourWorkload)
        {
            //IsDone = true;
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

    private static readonly int energyCostPerHour, satietyCostPerHour, happinessCoef;
    private int hourWorkload, hoursWorked, contractPrice;
    //private bool isDone;
    private Difficultys difficulty;
    private Player.ArtSkills.Techniques requiredTechnique;
    
    private Player.ArtSkills.Genres requiredGenre;
}