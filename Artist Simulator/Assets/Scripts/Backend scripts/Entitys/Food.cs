using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    public readonly int SatietyRestoration, Price, EatingTimeH;
    public readonly float DiseaseCoeff;
    public readonly string Name;

    public Food(string name, int price, int satietyRestoration, int eatingTimeH, float incDiseasePercent)
    {
        SatietyRestoration = satietyRestoration;
        Price = price;
        DiseaseCoeff = incDiseasePercent;
        EatingTimeH = eatingTimeH;
        Name = name;
    }
}
