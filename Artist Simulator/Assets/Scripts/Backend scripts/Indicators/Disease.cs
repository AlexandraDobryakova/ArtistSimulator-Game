using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease
{
    public Disease(string name, int costOfHealing, int timeOfHealing, float decreaseEnergyCoeff)
    {
        Name = name;
        CostOfHealing = costOfHealing;
        TimeOfHealing = timeOfHealing;
        DecreaseEnergyCoeff = decreaseEnergyCoeff;
        _decreaseEnergyCoeffWhenActive = decreaseEnergyCoeff;
        IsActive = false;
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
    public int TimeOfHealing { get => _timeOfHealing; private set => _timeOfHealing = value; }
    public float DecreaseEnergyCoeff 
    { 
        get => _currentDecreaseEnergyCoeff;

        private set 
        {
            _currentDecreaseEnergyCoeff = value;
        }  
    }
    public bool IsActive 
    { 
        get => _isActive;
        set 
        {
            DecreaseEnergyCoeff = value ? _decreaseEnergyCoeffWhenActive : 1f;
            Player.Energy.ValueCoeff = DecreaseEnergyCoeff;
        }
        
    }

    private bool _isActive;
    private string _name;
    private float _currentDecreaseEnergyCoeff;
    private readonly float  _decreaseEnergyCoeffWhenActive;
        
    private int _costOfHealing, _timeOfHealing; // time in hours

}
