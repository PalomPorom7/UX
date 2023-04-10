using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    [SerializeField]
    private Transform toMatch;

    [SerializeField]
    private Vector3 axis;

    private Vector3 eulers;

    private void Awake()
    {
        eulers = transform.eulerAngles;
    }
    private void LateUpdate()
    {
        eulers.z = toMatch.transform.eulerAngles.y;
        transform.eulerAngles = eulers;
    }
}
