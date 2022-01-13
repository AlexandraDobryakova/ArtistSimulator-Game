using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public static class GameConstants 
{
    public const int
        // Indicators:
        Money_start_value = 20,
        Money_max_value = 99999,

        Happiness_start_value = 100,
        Happiness_max_value = 100,

        Energy_start_value = 100,
        Energy_max_value = 100,

        Satiety_start_value = 100,
        Satiety_max_value = 100,

        // Actions:
        Sleep_energy_restore_perHour = 10,
        Sleep_satiety_decreasement = 20,
        Healing_cost = 50,
        Eating_duration_inHours = 2,
        //Learn_xp_increasement_perHour = 

        // Contracts
        Contracts_count = 5,
        Contracts_energyCostPerHour = 10,
        Contracts_satietyCostPerHour = 5,
        Contracts_happinessCoef = 5,
        Contracts_pool_changing_each_days = 10,

        // Disease
        Days_untill_tetting_Ill = 5,
        Illness_Chance_percent = 5,

        //Skills
        Skills_Max_lvl = 30,
        Skills_start_xp = 0,
        Skills_start_max_xp = 100,
        Skills_start_lvl = 1
        ;

    public const string
        Money_dimension = "$",
        Happiness_dimension = "%",
        Energy_dimension = "%",
        Satiety_dimension = "%"
        ;

    public const bool
        Money_is_vital = false,
        Happiness_is_vital = true,
        Energy_is_vital = true,
        Satiety_is_vital = true
        ;

    public static readonly Food[] FoodVariants =
        new Food[]
        {
            new Food("Лапша", 25, 20, 0, 0),
            new Food("Фастфуд", 50, 40, 1, 1.5f),
            new Food("Домашняя еда", 70, 30, 2, 1),
            new Food("Кафе", 80, 70, 1, 1),
            new Food("Ресторан", 90, 100, 2, 1)
        };


    public static readonly Dictionary<string, LearningVariant> LearningVariants =
        new Dictionary<string, LearningVariant>()
        {
            {"freeDrawing", new LearningVariant(1, 20, 0, 10, 10, 5) },
            {"watchingYoutube", new LearningVariant(2, 50, 0, 25, 25, 10) },
            {"expressCourse", new LearningVariant(5, 70, 50, 30, 30, 40) },
        };

    public static readonly Job[] Jobs =
        new Job[]
        {
            new Job("Sketch Art", true, 60 * 2, 15, 20, 20, +10),
            new Job("Pro sketch", true, 180 * 2, 25, 40, 25, +20),
            new Job("Art Studio", true, 150 * 2, 20, 25, 15, +15),
            new Job("Middle School", true, 25 * 2, 25, 40, 15, -5),
            new Job("Street graphics", true, 125 * 2, 10, 20, 20, +25),
            new Job("Shawerma king", false, 15 * 2, 0, 10, 15, -5),
            new Job("Roll prince", false, 20 * 2, 0, 15, 15, -10),
            new Job("Fast courier", false, 30 * 2, 0, 25, 30, -15)
        };
    
    //public static readonly Dictionary<string, Job> Jobs =
    //    new Dictionary<string, Job>()
    //    {
    //        {"courier", new Job("courier", false, 400, 0, 20, 15, -20)},
    //        {"macCashier", new Job("macCashier", false, 500, 0, 10, 5, -30)},
    //        {"juniorArtist", new Job("macCashier", true, 800, 3, 15, 15, 5)}
    //    };

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

    public static readonly string[] 
        techniquesNames =
    {
        "Кисти и холст",
        "Графический планшет",
        "Баллончик с краской",
        "Карандаш"
    }, 
        
        genresNames =
    {
        "Граффити",
        "Натюрморт",
        "Пейзаж",
        "Портрет",
        "Современное искусство"
    };

    public static readonly Disease DiseaseCold = new Disease("cold", 100, new GameTime(0, 3), 0.5f);
}
