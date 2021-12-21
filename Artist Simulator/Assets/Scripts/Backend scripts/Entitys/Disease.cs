using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease
{
    public Disease(string name, int costOfHealing, GameTime timeToHeal, float decreaseEnergyCoeff)
    {
        this.name = name;
        this.costOfHealing = costOfHealing;
        this.timeToHeal = timeToHeal;
        this.decreaseEnergyCoeff = decreaseEnergyCoeff;
        timeOfGettingIll = Game.Time;
    }

    public float decreaseEnergyCoeff;
    public readonly GameTime timeOfGettingIll, timeToHeal;
    public readonly string name;
    public readonly int costOfHealing;


    /*
    public Disease(string name, int costOfHealing, int daysToHeal, float decreaseEnergyCoeff)
    {
        Name = name;
        CostOfHealing = costOfHealing;
        DaysToHeal = daysToHeal;
        DecreaseEnergyCoeff = decreaseEnergyCoeff;
        timeOfGettingIll = Game.Time;
    }

    //TODO Владиация
    public string Name 
    { 
        get => _name; 
        private set => _name = value; 
    }

    public int CostOfHealing 
    { 
        get => _costOfHealing; 
        private set => _costOfHealing = value;
    }
    public int DaysToHeal { get => _daysToHeal; private set => _daysToHeal = value; }
    public float DecreaseEnergyCoeff 
    { 
        get => _currentDecreaseEnergyCoeff;

        private set 
        {
            _currentDecreaseEnergyCoeff = value;
        }  
    }
   
    private string _name;
    private float _currentDecreaseEnergyCoeff;
    private int _costOfHealing, _daysToHeal;
    private GameTime timeOfGettingIll;
    */
}

