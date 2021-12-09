using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static class ArtSkills
    {
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
                    _lvl = value >= _maxLvlSkill ? _maxLvlSkill : value;
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
                if(Lvl <= _maxLvlSkill)
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
            int res = GameConstans.Skills_start_lvl;

            foreach (var skill in _techniquesDict)
            {
                if (skill.Value.Lvl <= res)
                    res = skill.Value.Lvl;
            }

            foreach (var skill in _genresDict)
            {
                if (skill.Value.Lvl <= res)
                    res = skill.Value.Lvl;
            }

            return res;
        }

        public static void Initialize(int startXp, int startMaxXp, int startLvl, int MaxLvlSkill)
        {
            _maxLvlSkill = MaxLvlSkill;
            
            int techLen = Enum.GetValues(typeof(Techniques)).Length;
            int genLen = Enum.GetValues(typeof(Genres)).Length;

            _techniquesDict = new Dictionary<Techniques, Skill<Techniques>>();
            _genresDict = new Dictionary<Genres, Skill<Genres>>();

            for (int i = 0; i < techLen; i++)
                _techniquesDict.Add((Techniques)i, new Skill<Techniques>(startMaxXp, startLvl, startXp, (Techniques)i));

            for (int i = 0; i < genLen; i++)
                _genresDict.Add((Genres)i, new Skill<Genres>(startMaxXp, startLvl, startXp, (Genres)i));
        }

        public static Skill<Techniques> GetSkill(Techniques skillTeg) =>
            _techniquesDict[skillTeg];
        public static Skill<Genres> GetSkill(Genres skillTeg) =>
            _genresDict[skillTeg];
       

        private static int _maxLvlSkill, _generalLvl;
        private static Dictionary<Techniques, Skill<Techniques>> _techniquesDict;
        private static Dictionary<Genres, Skill<Genres>> _genresDict;
    }

    public static Indicator Money;
    public static Indicator Happiness;
    public static Indicator Energy;
    public static Indicator Satiety;

    public static Disease Disease;
    public static Contract CurrentContract;
    public static Job CurrentJob;

    public static bool HasAnEmployment, IsIll, IsWorkingOnContracrt;

    public static void Initialize()
    {
        ArtSkills.Initialize(
            GameConstans.Skills_start_xp, 
            GameConstans.Skills_start_max_xp,
            GameConstans.Skills_start_lvl, 
            GameConstans.Skills_max_lvl_skill);

        Money = new Indicator(
            GameConstans.Money_start_value,
            GameConstans.Money_max_value,
            GameConstans.Money_dimension,
            GameConstans.Money_is_vital);

        Happiness = new Indicator(
            GameConstans.Happiness_start_value,
            GameConstans.Happiness_max_value,
            GameConstans.Happiness_dimension,
            GameConstans.Happiness_is_vital);

        Energy = new Indicator(
            GameConstans.Energy_start_value,
            GameConstans.Energy_max_value,
            GameConstans.Energy_dimension,
            GameConstans.Energy_is_vital);

        Satiety = new Indicator(
            GameConstans.Satiety_start_value,
            GameConstans.Satiety_max_value,
            GameConstans.Satiety_dimension,
            GameConstans.Satiety_is_vital);

        //Disease = new Disease("cold", 1000, 24 * 2, 0.5f);

        IsIll = false;
        HasAnEmployment = false;
        IsWorkingOnContracrt = false;
    }
}
