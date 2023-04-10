using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private float hudScale = 0.5f;

    [SerializeField]
    private RectTransform   upperLeft,
                            upperMiddle,
                            upperRight,
                            lowerLeft,
                            lowerRight;

    private void Awake()
    {
        hudScale = PlayerPrefs.GetFloat("HUD Scale", hudScale);

        upperLeft.localScale    = new Vector3(hudScale, hudScale, 1);
        upperMiddle.localScale  = new Vector3(hudScale, hudScale, 1);
        upperRight.localScale   = new Vector3(hudScale, hudScale, 1);
        lowerLeft.localScale    = new Vector3(hudScale, hudScale, 1);
        lowerRight.localScale   = new Vector3(hudScale, hudScale, 1);
    }
}
