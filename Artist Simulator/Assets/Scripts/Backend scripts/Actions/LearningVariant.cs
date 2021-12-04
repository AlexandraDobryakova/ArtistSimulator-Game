using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LearningVariant
{
    //public readonly string name;
    public readonly int durationInHours, xpInc, leraningPrice, energyDecreasment, satietyDecreasment, happinessCoeff;

    public LearningVariant(
        //string name, 
        int durationInHours, 
        int xpInc, 
        int leraningPrice, 
        int energyDecreasment,  
        int satietyDecreasment, 
        int happinessCoeff)
    {
        //this.name = name;
        this.durationInHours = durationInHours;
        this.xpInc = xpInc;
        this.leraningPrice = leraningPrice;
        this.energyDecreasment = energyDecreasment;
        this.satietyDecreasment = satietyDecreasment;
        this.happinessCoeff = happinessCoeff;
    }
}

