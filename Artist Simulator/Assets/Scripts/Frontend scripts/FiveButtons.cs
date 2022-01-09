using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveButtons : MonoBehaviour
{
    private bool buttonIsClicked = false;
    public GameObject[] panels;
    public GameObject[] buttons;
    private int current_char = 0;
    //public GameObject workButton;
    //public static Vector3 wb;


    private void Start()
    {
        //wb = new Vector3(buttons[1].transform.position.x, buttons[1].transform.position.y, buttons[1].transform.position.z);
    }

    private void Update()
    {
        /*if (YouDied.IsDied == true)
        {
            buttons[1].SetActive(true);
            YouDied.IsDied = false;
            CloseThePanel();
            
        }*/
        
    }

    public void Click1Button()
    {
        //public static double x = workButton.transform.position.x; 
        
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 0;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 0;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click2Button()
    {
        
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 1;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 1;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click3Button()
    {
        if (buttonIsClicked == false)
        {

            buttonIsClicked = true;
            current_char = 2;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 2;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click4Button()
    {
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 3;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 3;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void Click5Button()
    {
        if (buttonIsClicked == false)
        {
            
            buttonIsClicked = true;
            current_char = 4;
            panels[current_char].SetActive(true);
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, buttons[current_char].transform.position.z);
        }
        else
        {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 4;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y + 0.1f, 0);
        }
        panels[current_char].SetActive(true);
    }

    public void CloseThePanel()
    {
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 0;
            buttonIsClicked = false;
       
    }

    public void CloseTheBUTTON()
    {

        if (YouDied.IsDied == true && buttonIsClicked == true)
        {
            //current_char = 1;
            buttons[current_char].transform.position = new Vector3(buttons[current_char].transform.position.x, buttons[current_char].transform.position.y - 0.1f, 0);
            panels[current_char].SetActive(false);
            current_char = 0;
            buttonIsClicked = false;
            YouDied.IsDied = false;
        }
    }
}