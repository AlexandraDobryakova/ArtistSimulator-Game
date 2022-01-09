using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BudgetLine : MonoBehaviour
{

    public GameObject text_budget;
    public Text text_CountOfMoney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FiveButtons.buttonIsClicked == true)
        {
            text_budget.SetActive(true);
            text_CountOfMoney.gameObject.SetActive(true);
        }
        else
        {
            text_budget.gameObject.SetActive(false);
            text_CountOfMoney.gameObject.SetActive(false);
        }
    }
}
