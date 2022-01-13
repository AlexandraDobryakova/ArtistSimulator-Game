using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Actions : MonoBehaviour
{
    public void Sleep(int sleepTime)
    {
        //Player.Energy.Value += GameConstants.Sleep_energy_restore_perHour * sleepTime;
        //Player.Satiety.Value -= GameConstants.Sleep_satiety_decreasement * sleepTime;
        Game.Time.Hours += sleepTime;
        var random = new System.Random(Guid.NewGuid().GetHashCode());
        if (random.Next(0, 101) <= GameConstants.Illness_Chance_percent && Player.CurrentDisease == null)
            Player.SetIll(GameConstants.DiseaseCold);
    }

    public void Heal()
    {
        if (Player.Money.Value >= GameConstants.Healing_cost)
        {
            Player.GetWell();
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

    public static void LearnTechnique(string skillName__learningVariant)
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
                //Player.Energy.Value -= learningVariant.energyDecreasment;
                //Player.Satiety.Value -= learningVariant.satietyDecreasment;
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
        {
            Game.ContractsPool[contractNumber].IsTaken = true;
            Player.CurrentContract = (Contract)Game.ContractsPool[contractNumber].Clone();
            Player.CurrentContract.TimeOfGetting = (GameTime)Game.Time.Clone();
            //Debug.Log($"TimeOfGetting: {Player.CurrentContract.TimeOfGetting.Days}, {Player.CurrentContract.TimeOfGetting.Hours}");
        }
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
        {
            Player.CurrentContract.DoWork(hoursOfWork);
            //Debug.Log($"DaysLeft = 10 - (Game.Time.Days - TimeOfGetting.Days) = \n" +
            //    $" 10 - ({Game.Time.Days} - {Player.CurrentContract.TimeOfGetting.Days}) = {Player.CurrentContract.GetDaysLeft()}");
        }
    }
}
