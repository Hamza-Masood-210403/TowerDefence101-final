using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel2 : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel ;
    public int levelToUnlock;

    public SceneFader sceneFader;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
