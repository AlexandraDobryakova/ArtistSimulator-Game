using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static class ArtSkills
    {
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
                    _lvl = value >= GameConstants.Skills_Max_lvl ? GameConstants.Skills_Max_lvl : value;
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
                if(Lvl <= GameConstants.Skills_Max_lvl)
                {
                    int oldMaxXp = MaxXp;
                    MaxXp = (int)(MaxXp * UpMaxXpCoeff);
                    Xp = gettingXp - oldMaxXp;
                    Lvl++;
                    _generalLvl++;
                }
            }
        }

        public static int GetMinSkillLvl()
        {
            int res = GameConstants.Skills_start_lvl;

            foreach (var skill in TechniquesDict)
            {
                if (skill.Value.Lvl <= res)
                    res = skill.Value.Lvl;
            }

            foreach (var skill in GenresDict)
            {
                if (skill.Value.Lvl <= res)
                    res = skill.Value.Lvl;
            }

            return res;
        }

        public static void Initialize(int startXp, int startMaxXp, int startLvl)
        {
            
            int techLen = Enum.GetValues(typeof(GameConstants.Techniques)).Length;
            int genLen = Enum.GetValues(typeof(GameConstants.Genres)).Length;

            TechniquesDict = new Dictionary<GameConstants.Techniques, Skill<GameConstants.Techniques>>();
            GenresDict = new Dictionary<GameConstants.Genres, Skill<GameConstants.Genres>>();

            for (int i = 0; i < techLen; i++)
                TechniquesDict.Add((GameConstants.Techniques)i, 
                    new Skill<GameConstants.Techniques>(startMaxXp, startLvl, startXp, (GameConstants.Techniques)i));

            for (int i = 0; i < genLen; i++)
                GenresDict.Add((GameConstants.Genres)i, 
                    new Skill<GameConstants.Genres>(startMaxXp, startLvl, startXp, (GameConstants.Genres)i));
        }

        public static Skill<GameConstants.Techniques> GetSkill(GameConstants.Techniques skillTeg) =>
            TechniquesDict[skillTeg];
        public static Skill<GameConstants.Genres> GetSkill(GameConstants.Genres skillTeg) =>
            GenresDict[skillTeg];

        public static int GeneralLvl { get => _generalLvl; private set { } }


        private static int _generalLvl;
        public static Dictionary<GameConstants.Techniques, Skill<GameConstants.Techniques>> TechniquesDict;
        public static Dictionary<GameConstants.Genres, Skill<GameConstants.Genres>> GenresDict;

    }

    public static Indicator Money;
    public static Indicator Happiness;
    public static Indicator Energy;
    public static Indicator Satiety;

    public static Disease CurrentDisease;
    public static Contract CurrentContract;
    public static Job CurrentJob;

    //public static bool HasAnEmployment, IsIll, IsWorkingOnContracrt;

    public static void Initialize()
    {
        ArtSkills.Initialize(
            GameConstants.Skills_start_xp, 
            GameConstants.Skills_start_max_xp,
            GameConstants.Skills_start_lvl);

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

        //IsIll = false;
        //HasAnEmployment = false;
        //IsWorkingOnContracrt = false;
    }
}
