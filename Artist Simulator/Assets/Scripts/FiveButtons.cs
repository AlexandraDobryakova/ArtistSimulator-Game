using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveButtons : MonoBehaviour
{
    public GameObject[] panels;
    private int current_char = 0;
    public void Click1Button()
    {
        panels[current_char].SetActive(false);
        current_char = 0;
        panels[current_char].SetActive(true);
    }

    public void Click2Button()
    {
        panels[current_char].SetActive(false);
        current_char = 1;
        panels[current_char].SetActive(true);
    }

    public void Click3Button()
    {
        panels[current_char].SetActive(false);
        current_char = 2;
        panels[current_char].SetActive(true);
    }

    public void Click4Button()
    {
        panels[current_char].SetActive(false);
        current_char = 3;
        panels[current_char].SetActive(true);
    }

    public void Click5Button()
    {
        panels[current_char].SetActive(false);
        current_char = 4;
        panels[current_char].SetActive(true);
    }

    public void CloseThePanel()
    {
        panels[current_char].SetActive(false);
    }
}