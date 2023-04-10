using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
    [SerializeField]
    private AccordionMenuItem[] menus;

    [SerializeField]
    private float stagger = 0.1f;

    private bool isOpen;

    public bool displayOpen, audioOpen;

    public void ToggleMenu()
    {
        isOpen = !isOpen;
        StartCoroutine(OpenMenu(isOpen));
    }

    public void Close()
    {
        StartCoroutine(OpenMenu(isOpen = false));
    }

    private IEnumerator OpenMenu(bool open)
    {
        if(displayOpen)
            menus[0].Expand(displayOpen = false);
        if(audioOpen)
            menus[1].Expand(audioOpen = false);

        foreach (AccordionMenuItem item in menus)
        {
            item.Hide(!open);
            yield return new WaitForSeconds(stagger);
        }
    }

    public void ToggleAccordionMenuItem(int index)
    {
        if(index == 0)
        {
            displayOpen = !displayOpen;
            menus[index].Expand(displayOpen);
            menus[1].MoveY(!displayOpen);

            if (displayOpen && audioOpen)
                menus[1].Expand(audioOpen = false);
        }
        else
        {
            audioOpen = !audioOpen;
            menus[index].Expand(audioOpen);

            if (displayOpen && audioOpen)
            {
                menus[0].Expand(displayOpen = false);
                menus[1].MoveY(true);
            }
        }
    }
}
