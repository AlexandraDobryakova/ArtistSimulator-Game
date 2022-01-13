using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text textHealth;
    private bool wasShowed = false;
    public GameObject panelHealth; 
    void Start()
    {
        
    }

    void Update()
    {
        if (Player.CurrentDisease == null)
        {
            textHealth.gameObject.SetActive(false);
            wasShowed = false;
        }
        else
        {
            textHealth.gameObject.SetActive(true);
        }

        if (Player.CurrentDisease != null && wasShowed == false)
        {
            panelHealth.SetActive(true);
            wasShowed = true;
        }

        
    }

    public void button_ClosePanelHealth()
    {
        panelHealth.SetActive(false);
    }
}
