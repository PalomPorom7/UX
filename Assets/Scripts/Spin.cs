using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private Vector3 axis;

    [SerializeField]
    private float degreesPerSecond = 1;

    [SerializeField]
    private bool playOnAwake = true;

    private Vector3 eulers, initial;
    private IEnumerator spinning;
    private bool isSpinning;

    public bool start, stop;

    private void Awake()
    {
        initial = transform.eulerAngles;
        eulers = initial;

        spinning = Spinning();

        if (playOnAwake)
            Play();
    }

    private void Update()
    {
        if (start)
        {
            Play();
            start = false;
        }
        if (stop)
        {
            Stop();
            stop = false;
        }
    }

    public void Play()
    {
        if(!isSpinning)
        {
            isSpinning = true;
            StartCoroutine(spinning);
        }
    }

    public void Stop()
    {
        if(isSpinning)
        {
            isSpinning = false;
            StopCoroutine(spinning);
            eulers = initial;
            transform.eulerAngles = eulers;
        }
    }

    private IEnumerator Spinning()
    {
        while (isSpinning)
        {
            eulers += axis * degreesPerSecond * Time.deltaTime;
            transform.eulerAngles = eulers;
            yield return null;
        }
    }
}
