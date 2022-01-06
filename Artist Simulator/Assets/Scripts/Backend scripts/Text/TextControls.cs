using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextControls : MonoBehaviour
{
    //[HideInInspector]
    public enum Values
    {
        NONE,
        Money,
        Happiness,
        Energy,
        Satiety,
        Employment,
        Salary,
        CurContract_DaysLeft,
        CurContract_Reward,
        CurContract_PercentExecution,
        General_lvl,
        Time,
        Disease_status,
        Cost_Of_Healing,
        Skill_Technique,
        Skill_Genre,
    };
    
    public enum XP_LVL_Selection
    {
        NONE,
        Xp,
        Lvl
    }

    public Text textObject;
    public Values showingValue;
    public GameConstants.Techniques SkillTechnique;
    public GameConstants.Genres SkillGenre;
    public XP_LVL_Selection SkillXpOrLvl;


    // Update is called once per frame
    void Update()
    {
        switch (showingValue)
        {
            case Values.Money:
                textObject.text = $"{Player.Money.Value}{Player.Money.Dimension}";
                break;

            case Values.Energy:
                textObject.text = $"{Player.Energy.Value}{Player.Energy.Dimension}";
                break;

            case Values.Happiness:
                textObject.text = $"{Player.Happiness.Value}{Player.Happiness.Dimension}";
                break;

            case Values.CurContract_DaysLeft:
                if (Player.CurrentContract != null)
                    textObject.text = $"{Player.CurrentContract.GetDaysLeft()}";
                break;

            case Values.CurContract_Reward:
                if (Player.CurrentContract != null)
                    textObject.text = $"{Player.CurrentContract.ContractPrice}{GameConstants.Money_dimension}";
                break;

            case Values.CurContract_PercentExecution:
                if (Player.CurrentContract != null)
                    textObject.text = $"{Player.CurrentContract.GetPercentExecution()}%";
                break;

            case Values.Satiety:
                textObject.text = $"{Player.Satiety.Value}{Player.Satiety.Dimension}";
                break;

            case Values.Time:
                textObject.text = $"days: {Game.Time.Days} time: {Game.Time.Hours}";
                break;
                
            case Values.General_lvl:
                textObject.text = $"{Player.ArtSkills.GeneralLvl}";
                break;

            case Values.Employment:
                    textObject.text = 
                    Player.CurrentJob != null ? $"{Player.CurrentJob.Name}" : "�� ������������";
                break;

            case Values.Cost_Of_Healing:
                textObject.text = $"{GameConstants.Healing_cost}{GameConstants.Money_dimension}";
                break;

            case Values.Salary:
                if(Player.CurrentJob != null)
                textObject.text = $"{Player.CurrentJob.SalaryPerHour}{GameConstants.Money_dimension}/�";
                break;

            case Values.Disease_status:
                textObject.text = Player.Disease == null ? "���" : Player.Disease.name;
                break;
                     
            case Values.Skill_Technique:
                if (SkillXpOrLvl == XP_LVL_Selection.NONE)
                    throw new ArgumentException("Select what to show: Xp or Lvl");
                if(SkillXpOrLvl == XP_LVL_Selection.Lvl)
                    textObject.text = $"{Player.ArtSkills.GetSkill(SkillTechnique).Lvl}";
                if (SkillXpOrLvl == XP_LVL_Selection.Xp)
                    textObject.text = 
                        $"{Player.ArtSkills.GetSkill(SkillTechnique).Xp} / " +
                        $"{Player.ArtSkills.GetSkill(SkillTechnique).MaxXp}";
                break;

            case Values.Skill_Genre:
                if (SkillXpOrLvl == XP_LVL_Selection.NONE)
                    throw new ArgumentException("Select what to show: Xp or Lvl");
                if (SkillXpOrLvl == XP_LVL_Selection.Lvl)
                    textObject.text = $"{Player.ArtSkills.GetSkill(SkillGenre).Lvl}";
                if (SkillXpOrLvl == XP_LVL_Selection.Xp)
                    textObject.text = 
                        $"{Player.ArtSkills.GetSkill(SkillGenre).Xp} / " +
                        $"{Player.ArtSkills.GetSkill(SkillTechnique).MaxXp}";
                break;

            default:
                textObject.text = "<--->";
                throw new ArgumentException("Select a showing value");
        }
    }
}
