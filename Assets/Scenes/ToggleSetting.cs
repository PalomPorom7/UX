using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleSetting : MonoBehaviour
{
    private bool value;

    [SerializeField]
    private Text display;

    [SerializeField]
    private UnityEvent<bool> updateSetting;

    private void UpdateDisplay()
    {
        display.text = value ? "ON" : "OFF";
    }

    public void SetInitialValue(bool value)
    {
        this.value = value;
        UpdateDisplay();
    }

    public void Toggle()
    {
        value = !value;
        UpdateDisplay();
        updateSetting.Invoke(value);
    }
}
