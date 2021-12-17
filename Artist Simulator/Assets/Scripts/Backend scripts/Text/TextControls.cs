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
        General_lvl,
        Time,
        Disease,
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

    void Start()
    {
        
    }

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
                    Player.CurrentJob != null ? $"{Player.ArtSkills.GeneralLvl}" : "не трудоустроен";
                break;
                     
            case Values.Disease:
                textObject.text = Player.Disease == null ? "нет" : Player.Disease.name;
                    
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
