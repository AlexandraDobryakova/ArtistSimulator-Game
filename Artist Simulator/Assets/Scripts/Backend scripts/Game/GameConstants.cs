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
        Money_dimension = "�",
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

    /*
     ��������, ���������, +�������, �����, ���������� ����� �������, +������� ��������
1. ����� �/�, 25, 20, 0, *2, 0
2. �������, 50, 40, 1���, *1.5, 0
3. �������� ���, 70, 30, 2����, *1, 0
4. ����, 80, 70, 1���, *1, +15
5. ��������, 90, 100, *1, +25
    */

    public static readonly Dictionary<string, (int satietyRestoration, int priceOfFood)> Food =
        new Dictionary<string, (int satietyRestoration, int priceOfFood)>
        {
            {"�����", (5, 25) },
            {"�������", (15, 50) },
            {"�������� ���", (50, 200) },
            {"����", (50, 200) },
            {"��������", (50, 200) }
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
        "����� � �����",
        "����������� �������",
        "��������� � �������",
        "��������"
    }, 
        
        genresNames =
    {
        "��������",
        "���������",
        "������",
        "�������",
        "����������� ���������"
    };

    public static readonly Disease DiseaseCold = new Disease("cold", 1000, new GameTime(0, 3), 0.5f);
}
