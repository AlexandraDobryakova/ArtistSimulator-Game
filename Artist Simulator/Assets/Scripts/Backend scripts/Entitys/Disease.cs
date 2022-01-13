using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Disease
{
    public Disease(string name, int costOfHealing, GameTime timeToHeal, float decreaseEnergyCoeff)
    {
        DecreaseEnergyCoeff = decreaseEnergyCoeff;
        _name = name;
        _costOfHealing = costOfHealing;
        _timeToHeal = timeToHeal;
        _timeOfGettingIll = (GameTime)Game.Time.Clone();
    }

    [SerializeField]
    public float DecreaseEnergyCoeff;
    [SerializeField]
    private GameTime _timeToHeal, _timeOfGettingIll;
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _costOfHealing;

    public GameTime TimeOfGettingIll { get => _timeOfGettingIll; }
    public GameTime TimeToHeal { get => _timeToHeal; }
    public string Name { get => _name; }
    public int CostOfHealing { get => _costOfHealing; }
}

