using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static class ArtSkills
    {
        public static int MinSkillsLvl;
        public enum Techniques
        {
            Brush = 0,
            GraphicsTablet = 1,
            SprayPaint = 2,
            Pencil = 3
        }

        public enum Genres
        {
            Graffiti = 0,
            StillLife = 1,
            Scenery = 2,
            Portrait = 3,
            ModernArt = 4
        }
        public class Skill <SkillType>
        {
            public Skill(int maxXp, int lvl, int xp, SkillType skillTeg)
            {
                MaxXp = maxXp;
                Lvl = lvl;
                Xp = xp;
                SkillTeg = skillTeg;
            }

            public int MaxXp { get => _maxXp; set => _maxXp = value; }
            public int Lvl 
            { 
                get => _lvl;
                set 
                {
                    _lvl = value >= MaxLvlSkill ? MaxLvlSkill : value;
                } 
            }
            public int Xp 
            { 
                get => _xp;
                set 
                {
                    if (value >= MaxXp)
                        LvlUp(value);
                    else
                        _xp = value;
                }
            }
           
            public SkillType SkillTeg { get => _skillTeg; set => _skillTeg = value; }

            private static readonly float UpMaxXpCoeff = 1.5f;
            private int _maxXp;
            private int _lvl;
            private int _xp;
            private SkillType _skillTeg;

            //TODO: проверить рекурсию
            private void LvlUp(int gettingXp)
            {
                if(Lvl <= MaxLvlSkill)
                {
                    int oldMaxXp = MaxXp;
                    MaxXp = (int)(MaxXp * UpMaxXpCoeff);
                    Xp = gettingXp - oldMaxXp;
                    Lvl++;

                    foreach (var skill in techniquesDict)
                    {
                        if (skill.Value.Lvl < MinSkillsLvl)
                            MinSkillsLvl = skill.Value.Lvl;
                    }

                    foreach (var skill in genresDict)
                    {
                        if (skill.Value.Lvl < MinSkillsLvl)
                            MinSkillsLvl = skill.Value.Lvl;
                    }
                }
            }
        }


        public static void Initialize(int startXp, int startMaxXp, int startLvl, int MaxLvlSkill)
        {
            MinSkillsLvl = 1;
            ArtSkills.MaxLvlSkill = MaxLvlSkill;
            
            int techLen = Enum.GetValues(typeof(Techniques)).Length;
            int genLen = Enum.GetValues(typeof(Genres)).Length;

            techniquesDict = new Dictionary<Techniques, Skill<Techniques>>();
            genresDict = new Dictionary<Genres, Skill<Genres>>();

            for (int i = 0; i < techLen; i++)
                techniquesDict.Add((Techniques)i, new Skill<Techniques>(startMaxXp, startLvl, startXp, (Techniques)i));

            for (int i = 0; i < genLen; i++)
                genresDict.Add((Genres)i, new Skill<Genres>(startMaxXp, startLvl, startXp, (Genres)i));
        }

        public static Skill<Techniques> GetSkill(Techniques skillTeg) =>
            techniquesDict[skillTeg];
        public static Skill<Genres> GetSkill(Genres skillTeg) =>
            genresDict[skillTeg];
       

        private static int MaxLvlSkill;
        private static Dictionary<Techniques, Skill<Techniques>> techniquesDict;
        private static Dictionary<Genres, Skill<Genres>> genresDict;
    }

    public static Indicator Money;
    public static Indicator Happiness;
    public static Indicator Energy;
    public static Indicator Satiety;

    public static Disease Disease;
    public static Contract CurrentContract;
    public static Job Employment;

    public static bool HasAnEmployment, IsIll, IsWorkingOnContracrt;

    public static void Initialize()
    {
        ArtSkills.Initialize(
            GameConstants.Skills_start_xp, 
            GameConstants.Skills_start_max_xp,
            GameConstants.Skills_start_lvl, 
            GameConstants.Skills_max_lvl_skill);

        Money = new Indicator(
            GameConstants.Money_start_value,
            GameConstants.Money_max_value,
            GameConstants.Money_dimension,
            GameConstants.Money_is_vital);

        Happiness = new Indicator(
            GameConstants.Happiness_start_value,
            GameConstants.Happiness_max_value,
            GameConstants.Happiness_dimension,
            GameConstants.Happiness_is_vital);

        Energy = new Indicator(
            GameConstants.Energy_start_value,
            GameConstants.Energy_max_value,
            GameConstants.Energy_dimension,
            GameConstants.Energy_is_vital);

        Satiety = new Indicator(
            GameConstants.Satiety_start_value,
            GameConstants.Satiety_max_value,
            GameConstants.Satiety_dimension,
            GameConstants.Satiety_is_vital);

        //Disease = new Disease("cold", 1000, 24 * 2, 0.5f);

        IsIll = false;
        HasAnEmployment = false;
        IsWorkingOnContracrt = false;
    }
}
