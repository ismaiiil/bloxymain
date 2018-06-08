using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConfirmQuit : MonoBehaviour {

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit button pressed");
    }
}
