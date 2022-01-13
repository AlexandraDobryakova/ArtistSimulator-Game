using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkInformation : MonoBehaviour
{
    public Text[] namefWork;
    public Text[] levelOfWork;
    public Text[] salaryOfWork;

    
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            namefWork[i].text = GameConstants.Jobs[i].Name;
            levelOfWork[i].text = GameConstants.Jobs[i].MinRequiredLvlSkills.ToString() + " уровень";
            salaryOfWork[i].text = GameConstants.Jobs[i].SalaryPerHour.ToString() + "$/ч";
        }
    }
}
