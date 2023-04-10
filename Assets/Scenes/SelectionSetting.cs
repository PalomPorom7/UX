using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectionSetting : MonoBehaviour
{
    private int value;

    [SerializeField]
    private Text display;

    [SerializeField]
    private string[] options;

    [SerializeField]
    private UnityEvent<int> updateSetting;

    private void Awake()
    {
        if(options.Length == 0)
            options = new string[] { "NULL" };
    }

    private void UpdateDisplay()
    {
        if(display != null)
            display.text = options[value];
    }

    public void SetOptions(string[] options)
    {
        this.options = options;
        UpdateDisplay();
    }

    public void SetInitialValue(int value)
    {
        this.value = value;
        UpdateDisplay();
    }

    public void Cycle(bool right)
    {
        if(right)
        {
            if(++value == options.Length)
                value = 0;
        }
        else if (--value == -1)
            value += options.Length;

        UpdateDisplay();
        updateSetting.Invoke(value);
    }
}
