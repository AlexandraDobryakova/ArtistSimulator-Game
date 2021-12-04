using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Job : Work
{
    public Job(string name, bool isByProfession, int salaryPerHour, int minRequiredLvlSkills,
        int energyCostPerHour, int satietyCostPerHour, int happinessCoef) :
        base(name, energyCostPerHour, satietyCostPerHour, happinessCoef)
    {
        this.salaryPerHour = salaryPerHour;
        this.isByProfession = isByProfession;
        this.minRequiredLvlSkills = minRequiredLvlSkills;
    }

    public int SalaryPerHour => salaryPerHour;

    public bool IsByProfession => isByProfession;

    public int MinRequiredLvlSkills => minRequiredLvlSkills;

    public override void DoWork(int hoursOfWork)
    {
        Player.Energy.Value -= EnergyCostPerHour * hoursOfWork;
        Player.Satiety.Value -= SatietyCostPerHour * hoursOfWork;
        Player.Happiness.Value += isByProfession ? HappinessCoef * hoursOfWork : - HappinessCoef * hoursOfWork;
        Player.Money.Value += salaryPerHour * hoursOfWork;
        //GameTime.Hours += hoursOfWork;

        if (isByProfession)
        {
            int techLen = Enum.GetValues(typeof(Player.ArtSkills.Techniques)).Length;
            int genreLen = Enum.GetValues(typeof(Player.ArtSkills.Genres)).Length;

            System.Random rd = new System.Random();
            Player.ArtSkills.Techniques randTech = (Player.ArtSkills.Techniques)rd.Next(0, techLen);
            Player.ArtSkills.Genres randGenre = (Player.ArtSkills.Genres)rd.Next(0, genreLen);

            Player.ArtSkills.GetSkill(randTech).Xp += GetXPInc(hoursOfWork);
            Player.ArtSkills.GetSkill(randGenre).Xp += GetXPInc(hoursOfWork);
        }
    }

    public override int GetXPInc(int hoursOfWork)
    {
        return (int)(hoursOfWork * 1.5);
    }

    private readonly int salaryPerHour, minRequiredLvlSkills;
    private readonly bool isByProfession;
}
