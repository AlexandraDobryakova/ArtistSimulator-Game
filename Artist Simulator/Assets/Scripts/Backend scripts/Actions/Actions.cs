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
        if(Player.Money.Value >= GameConstants.Healing_cost)
        {
            Player.Disease = null;
            Player.Money.Value -= GameConstants.Healing_cost;
        }
    }

    public void Eat(string foodName) 
    {
        if (!GameConstants.Food.ContainsKey(foodName))
            throw new ArgumentException($"Wrong name of food: \"{foodName}\".");

        if (Player.Money.Value >= GameConstants.Food[foodName].priceOfFood)
        {
            Player.Satiety.Value += GameConstants.Food[foodName].satietyRestoration;
            Player.Money.Value -= GameConstants.Food[foodName].priceOfFood;
            Game.Time.Hours += GameConstants.Eating_duration_inHours;
        }
    }

    public void LearnTechnique(string skillName_learningVariant)
    {
        if (!skillName_learningVariant.Contains(' '))
            throw new ArgumentException($"Wrong argument format: \"{skillName_learningVariant}\". There must be a ' '.");

        var args = skillName_learningVariant.Split(' ');

        if(args.Length != 2)
            throw new ArgumentException(
                $"Wrong argument format: \"{skillName_learningVariant}\". There must be only 2 args.");


        if (GameConstants.LearningVariants.TryGetValue(args[1], out var learningVariant))
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
                        $"Wrong argument: \"{skillName_learningVariant}\". Unknown SkillName: \"{args[0]}\"");
            }
        }
        else
            throw new ArgumentException(
                $"Wrong argument: \"{skillName_learningVariant}\". Unknown LearningVariant: \"{args[1]}\"");
    }
}
