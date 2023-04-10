using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsMenu;

    private void Start()
    {
        //  Check if a save file exists
        //  If it does, enable the continue button
    }

    public void NewGame()
    {
        //  Create a new save file
        //  Launch a new game
    }

    public void Continue()
    {
        //  Load the save file and launch main scene
    }

    public void Settings()
    {
        settingsMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
