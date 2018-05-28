using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;

    public Button[] LevelButtons;
    

    void Start()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            if (i+1 > levelReached)
            {
                LevelButtons[i].GetComponentInChildren<TextMeshProUGUI>().color =
                    LevelButtons[i].GetComponentInChildren<TextMeshProUGUI>().color - new Color(0, 0, 0, 0.5f);
                LevelButtons[i].interactable = false;
                
            }
            else
            {
                LevelButtons[i].interactable = true;
            }

            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }


}
