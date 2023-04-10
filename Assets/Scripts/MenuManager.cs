using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Fader blackscreen;

    [SerializeField]
    private MenuItem[] menus;

    [SerializeField]
    private float stagger = 0.1f;

    [SerializeField]
    private SettingsMenuManager settings;

    private bool isOpen;

    private void Start()
    {
        StartCoroutine(blackscreen.Fade(0));
    }

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        StartCoroutine(OpenMenu(isOpen));
    }

    private IEnumerator OpenMenu(bool open)
    {
        if(!open)
            settings.Close();

        foreach(MenuItem item in menus)
        {
            item.Hide(!open);
            yield return new WaitForSeconds(stagger);
        }
    }

    public void Refresh()
    {
        StartCoroutine(Refreshing());
    }

    private IEnumerator Refreshing()
    {
        yield return StartCoroutine(blackscreen.Fade(1));
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        StartCoroutine(Exiting());
    }

    private IEnumerator Exiting()
    {
        yield return StartCoroutine(blackscreen.Fade(1));
        Application.Quit();
    }
}
