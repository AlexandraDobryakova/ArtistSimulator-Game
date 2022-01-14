using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
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

    public bool IsAvailable() => Player.ArtSkills.GetMinSkillLvl() >= minRequiredLvlSkills;

    public override void DoWork(int hoursOfWork)
    {
        Player.Energy.Value -= EnergyCostPerHour * hoursOfWork;
        Player.Satiety.Value -= (int)(SatietyCostPerHour/* * 0.6*/ * hoursOfWork);
        Player.Happiness.Value += HappinessCoef * hoursOfWork;
        Player.Money.Value += salaryPerHour * hoursOfWork;
        Game.Time.Hours += hoursOfWork;

        if (isByProfession)
        {
            int techLen = Enum.GetValues(typeof(GameConstants.Techniques)).Length;
            int genreLen = Enum.GetValues(typeof(GameConstants.Genres)).Length;

            System.Random rd = new System.Random();
            GameConstants.Techniques randTech = (GameConstants.Techniques)rd.Next(0, techLen);
            GameConstants.Genres randGenre = (GameConstants.Genres)rd.Next(0, genreLen);

            Player.ArtSkills.GetSkill(randTech).Xp += GetXPInc(hoursOfWork);
            Player.ArtSkills.GetSkill(randGenre).Xp += GetXPInc(hoursOfWork);
        }
    }

    protected override int GetXPInc(int hoursOfWork)
    {
        return (int)(hoursOfWork * 1.5);
    }

    [SerializeField]
    private int salaryPerHour, minRequiredLvlSkills;
    [SerializeField]
    private bool isByProfession;
}
