using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{

    public void OnApplicationQuit() {
        Debug.Log("Application ending after " + Time.time + " seconds");
        Game.Save();
    }
}
