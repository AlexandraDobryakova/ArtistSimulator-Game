using System;
using System.Collections;
using System.Collections.Generic;
public static class GameConstans 
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
        Eating_duration_inHours = 2,
        //Learn_xp_increasement_perHour = 

        // Contracts
        Contracts_count = 5,
        Contracts_energyCostPerHour = 10,
        Contracts_satietyCostPerHour = 5,
        Contracts_happinessCoef = 5,

        // Disease
        DaysUntillGettingIll = 5
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

    public static readonly Dictionary<string, (int satietyRestoration, int priceOfFood)> Food =
        new Dictionary<string, (int satietyRestoration, int priceOfFood)>
        {
            {"bread", (5, 25) },
            {"doshirak", (15, 50) },
            {"dumplings", (50, 200) }
        };


    public static readonly Dictionary<string, LearningVariant> LearningVariants = 
        new Dictionary<string, LearningVariant>()
        {
            {"freeDrawing", new LearningVariant(1, 20, 0, 10, 10, 5) },
            {"watchingYoutube", new LearningVariant(2, 50, 0, 25, 25, 10) },
            {"expressCourse", new LearningVariant(5, 200, 1000, 30, 30, 40) },
        };


    public static readonly Dictionary<string, Job> Jobs =
        new Dictionary<string, Job>()
        {
            {"courier", new Job("courier", false, 400, 0, 20, 15, -20)},
            {"macCashier", new Job("macCashier", false, 500, 0, 10, 5, -30)},
            {"juniorArtist", new Job("macCashier", true, 800, 3, 15, 15, 5)}
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

    public static readonly Disease DiseaseCold = new Disease("cold", 1000, new GameTime(0, 3), 0.5f);
}
