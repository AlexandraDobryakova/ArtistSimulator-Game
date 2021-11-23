using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
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
                set => _lvl = value >= MaxLvlSkill ? MaxLvlSkill : value;

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
            private void LvlUp(int newXp)
            {
                if(Lvl <= MaxLvlSkill)
                {
                    int oldMaxXp = MaxXp;
                    MaxXp = (int)(MaxXp * UpMaxXpCoeff);
                    Xp = newXp - oldMaxXp;
                    Lvl++;
                }
            }
        }


        public static void Initialize(int startXp, int startMaxXp, int startLvl, int MaxLvlSkill)
        {
            ArtSkills.MaxLvlSkill = MaxLvlSkill;
            
            int techLen = Enum.GetValues(typeof(Techniques)).Length;
            int genLen = Enum.GetValues(typeof(Genres)).Length;

            for (int i = 0; i < techLen; i++)
                techniquesDict.Add((Techniques)i, new Skill<Techniques>(startMaxXp, startLvl, startXp, (Techniques)i));

            for (int i = 0; i < genLen; i++)
                genresDict.Add((Genres)i, new Skill<Genres>(startMaxXp, startLvl, startXp, (Genres)i));
        }

        private static int MaxLvlSkill;
        private static Dictionary<Techniques, Skill<Techniques>> techniquesDict;
        private static Dictionary<Genres, Skill<Genres>> genresDict;
    }

    public static Indicator Money;
    public static Indicator Happiness;
    public static Indicator Energy;
    public static Indicator Satiety;
    public static Disease Disease;

    public static void Initialize()
    {
        ArtSkills.Initialize(0, 100, 1, 30);
        Disease = new Disease("cold", 1000, 24 * 2, 0.5f);
        Money = new Indicator(5000, 999999, "р");
        Happiness = new Indicator(100, 100, "%");
        Energy = new Indicator(100, 100, "%");
        Satiety = new Indicator(100, 100, "%");
    }
}
