using System;
using System.Collections;
using System.Collections.Generic;
public static class GameConstants 
{
    public const int
        // Indicators:
        Money_start_value = 1000,
        Money_max_value = 99999,

        Happiness_start_value = 100,
        Happiness_max_value = 100,

        Energy_start_value = 100,
        Energy_max_value = 100,

        Satiety_start_value = 100,
        Satiety_max_value = 100,

        Skills_start_xp = 0,
        Skills_start_max_xp = 100,
        Skills_start_lvl = 1,
        Skills_max_lvl_skill = 30,

        // Actions:
        Sleep_energy_restore_perHour = 40,
        Sleep_satiety_decreasement = 20,
        Healing_cost = 1000,
        Eating_duration_inHours = 2
        //Learn_xp_increasement_perHour = 
        ;

    public const string
        Money_dimension = "р",
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

    public static Dictionary<string, (int satietyRestoration, int priceOfFood)> Food =
        new Dictionary<string, (int satietyRestoration, int priceOfFood)>
        {
            {"bread", (5, 25) },
            {"doshirak", (15, 50) },
            {"dumplings", (50, 200) }
        };


    public static Dictionary<string, LearningVariant> LearningVariants =
        new Dictionary<string, LearningVariant>()
        {
            {"freeDrawing", new LearningVariant(1, 20, 0, 10, 10, 5) },
            {"watchingYoutube", new LearningVariant(2, 50, 0, 25, 25, 10) },
            {"expressCourse", new LearningVariant(5, 200, 1000, 30, 30, 40) },
        };


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

    public static Disease DiseaseCold = new Disease("cold", 1000, 24 * 2, 0.5f);
}
