using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Actions : MonoBehaviour
{
    public void Sleep(int sleepTime)
    {
        Player.Energy.Value += GameConstans.Sleep_energy_restore_perHour * sleepTime;
        Player.Satiety.Value -= GameConstans.Sleep_satiety_decreasement;
        Game.Time.Hours += sleepTime;
    }

    public void Heal() 
    {
        if(Player.Money.Value >= GameConstans.Healing_cost)
        {
            Player.Disease = null;
            Player.Money.Value -= GameConstans.Healing_cost;
        }
    }

    public void Eat(string foodName) 
    {
        if (!GameConstans.Food.ContainsKey(foodName))
            throw new ArgumentException($"Wrong name of food: \"{foodName}\".");

        if (Player.Money.Value >= GameConstans.Food[foodName].priceOfFood)
        {
            Player.Satiety.Value += GameConstans.Food[foodName].satietyRestoration;
            Player.Money.Value -= GameConstans.Food[foodName].priceOfFood;
            Game.Time.Hours += GameConstans.Eating_duration_inHours;
        }
    }

    public void LearnTechnique(string skillName__learningVariant)
    {
        if (!skillName__learningVariant.Contains(' '))
            throw new ArgumentException($"Wrong argument format: \"{skillName__learningVariant}\". Here must be a ' '.");

        var args = skillName__learningVariant.Split(' ');

        if(args.Length != 2)
            throw new ArgumentException(
                $"Wrong argument format: \"{skillName__learningVariant}\". Here can be only 2 args.");


        if (GameConstans.LearningVariants.TryGetValue(args[1], out var learningVariant))
        {
            if (Player.Money.Value >= learningVariant.leraningPrice)
            {
                Player.Energy.Value -= learningVariant.energyDecreasment;
                Player.Satiety.Value -= learningVariant.satietyDecreasment;
                Player.Happiness.Value += learningVariant.happinessCoeff;
                Player.Money.Value -= learningVariant.leraningPrice;
                Game.Time.Hours += learningVariant.durationInHours;

                if (Enum.TryParse(args[0], out Player.ArtSkills.Techniques tech))
                    Player.ArtSkills.GetSkill(tech).Xp += learningVariant.xpInc;

                else if (Enum.TryParse(args[0], out Player.ArtSkills.Genres genre))
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
        if(contractNumber > GameConstans.Contracts_count - 1)
            throw new ArgumentException(
                $"Wrong argument: \"{contractNumber}\"." +
                $"ContractNumber can't be more than {GameConstans.Contracts_count - 1}");
        if (Player.CurrentContract == null)
            Player.CurrentContract = Game.ContractsPool[contractNumber];
    }

    public void TakeJob(string jobName)
    {
        if(!GameConstans.Jobs.ContainsKey(jobName))
            throw new ArgumentException($"Wrong argument: \"{jobName}\". Unknown Job.");
        if(Player.ArtSkills.GetMinSkillLvl() >= GameConstans.Jobs[jobName].MinRequiredLvlSkills)
            Player.CurrentJob = GameConstans.Jobs[jobName];
    }
}
