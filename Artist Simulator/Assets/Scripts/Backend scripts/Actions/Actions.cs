using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Actions : MonoBehaviour
{
    public void Sleep(int sleepTime)
    {
        Player.Energy.Value += GameConstants.Sleep_energy_restore_perHour * sleepTime;
        Player.Satiety.Value -= GameConstants.Sleep_satiety_decreasement;
        Game.Time.Hours += sleepTime;
    }

    public void Heal()
    {
        if (Player.Money.Value >= GameConstants.Healing_cost)
        {
            Player.Disease = null;
            Player.Money.Value -= GameConstants.Healing_cost;
        }
    }

    public void Eat(int foodNumber)
    {
        if (foodNumber < 0 || foodNumber > GameConstants.FoodVariants.Length)
            throw new ArgumentException($"Food number can be only in range[0, {GameConstants.FoodVariants.Length}]");

        if (Player.Money.Value >= GameConstants.FoodVariants[foodNumber].Price)
        {
            Player.Satiety.Value += GameConstants.FoodVariants[foodNumber].SatietyRestoration;
            Player.Money.Value -= GameConstants.FoodVariants[foodNumber].Price;
            Game.Time.Hours += GameConstants.FoodVariants[foodNumber].EatingTimeH;
        }
    }

    public void LearnTechnique(string skillName__learningVariant)
    {
        if (!skillName__learningVariant.Contains(' '))
            throw new ArgumentException($"Wrong argument format: \"{skillName__learningVariant}\". Here must be a ' '.");

        var args = skillName__learningVariant.Split(' ');

        if (args.Length != 2)
            throw new ArgumentException(
                $"Wrong argument format: \"{skillName__learningVariant}\". Here can be only 2 args.");

        if (GameConstants.LearningVariants.TryGetValue(args[1], out var learningVariant))
        {
            if (Player.Money.Value >= learningVariant.leraningPrice)
            {
                Player.Energy.Value -= learningVariant.energyDecreasment;
                Player.Satiety.Value -= learningVariant.satietyDecreasment;
                Player.Happiness.Value += learningVariant.happinessCoeff;
                Player.Money.Value -= learningVariant.leraningPrice;
                Game.Time.Hours += learningVariant.durationInHours;

                if (Enum.TryParse(args[0], out GameConstants.Techniques tech))
                    Player.ArtSkills.GetSkill(tech).Xp += learningVariant.xpInc;

                else if (Enum.TryParse(args[0], out GameConstants.Genres genre))
                    Player.ArtSkills.GetSkill(genre).Xp += learningVariant.xpInc;
                else
                    throw new ArgumentException(
                        $"Wrong argument: \"{skillName__learningVariant}\". Unknown SkillName: \"{args[0]}\"");
            }
        }
        else
            throw new ArgumentException(
                $"Wrong argument: \"{skillName__learningVariant}\". Unknown LearningVariant: \"{args[1]}\"");
    }

    public void TakeContract(int contractNumber)
    {
        if (contractNumber > GameConstants.Contracts_count - 1)
            throw new ArgumentException(
                $"Wrong argument: \"{contractNumber}\"." +
                $"ContractNumber can't be more than {GameConstants.Contracts_count - 1}");
        if (Player.CurrentContract == null)
            Player.CurrentContract = Game.ContractsPool[contractNumber];
    }

    public void TakeJob(int jobNumber)
    {
        if (jobNumber < 0 || jobNumber > GameConstants.Jobs.Length)
            throw new ArgumentException($"Job number can be only in range[0, {GameConstants.FoodVariants.Length}]");
        if (Player.ArtSkills.GetMinSkillLvl() >= GameConstants.Jobs[jobNumber].MinRequiredLvlSkills)
            Player.CurrentJob = GameConstants.Jobs[jobNumber];
    }

    public void DoJob(int hoursOfWork)
    {
        if (Player.CurrentJob != null)
            Player.CurrentJob.DoWork(hoursOfWork);
    }

    public void DoContract(int hoursOfWork)
    {
        if (Player.CurrentContract != null)
            Player.CurrentContract.DoWork(hoursOfWork);
    }
}
