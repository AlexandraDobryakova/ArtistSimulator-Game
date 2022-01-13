using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Player
{
    [System.Serializable]
    public static class ArtSkills
    {
        [System.Serializable]
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

            [SerializeField]
            private static readonly float UpMaxXpCoeff = 1.5f;
            [SerializeField]
            private int _maxXp, _lvl, _xp;
            [SerializeField]
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

            foreach (var skill in TechniquesList)
            {
                if (skill.Lvl <= res)
                    res = skill.Lvl;
            }

            foreach (var skill in GenresList)
            {
                if (skill.Lvl <= res)
                    res = skill.Lvl;
            }

            return res;
        }

        public static void Initialize(int startXp, int startMaxXp, int startLvl)
        {
            
            int techLen = Enum.GetValues(typeof(GameConstants.Techniques)).Length;
            int genLen = Enum.GetValues(typeof(GameConstants.Genres)).Length;

            TechniquesList = new List<Skill<GameConstants.Techniques>>();
            GenresList = new List<Skill<GameConstants.Genres>>();

            for (int i = 0; i < techLen; i++)
                TechniquesList.Add(new Skill<GameConstants.Techniques>(startMaxXp, startLvl, startXp, (GameConstants.Techniques)i));

            for (int i = 0; i < genLen; i++)
                GenresList.Add(new Skill<GameConstants.Genres>(startMaxXp, startLvl, startXp, (GameConstants.Genres)i));
        }

        public static Skill<GameConstants.Techniques> GetSkill(GameConstants.Techniques skillTeg) =>
            TechniquesList.Find(x => x.SkillTeg == skillTeg);
        public static Skill<GameConstants.Genres> GetSkill(GameConstants.Genres skillTeg) =>
            GenresList.Find(x => x.SkillTeg == skillTeg);

        public static int GeneralLvl { get => _generalLvl; set => _generalLvl = value; }


        private static int _generalLvl;

        public static List<Skill<GameConstants.Techniques>> TechniquesList;
        public static List<Skill<GameConstants.Genres>> GenresList;

    }

    public static Indicator Money, Happiness, Energy, Satiety;

    public static Disease CurrentDisease;

    public static Contract CurrentContract;

    public static Job CurrentJob;

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

        CurrentContract = null;
        CurrentDisease = null;
        CurrentJob = null;

        //Disease = new Disease("cold", 1000, 24 * 2, 0.5f);

        //IsIll = false;
        //HasAnEmployment = false;
        //IsWorkingOnContracrt = false;
    }

    public static void SetIll(Disease disease)
    {
        CurrentDisease = disease;
        Energy.ValueCoeff = disease.DecreaseEnergyCoeff;
    }

    public static void GetWell()
    {
        CurrentDisease = null;
        Energy.ValueCoeff = 1.0f;
    }
}
