using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkPanel : MonoBehaviour
{
    public Text nameOfContract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.CurrentContract != null)
            nameOfContract.text = "Контракт: " + Player.CurrentContract.requiredGenre + ", " + Player.CurrentContract.requiredTechnique;
        else
            nameOfContract.text = "Контракт: ---";
    }
}
