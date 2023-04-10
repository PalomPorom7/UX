using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccordionMenuItem : MenuItem
{
    [SerializeField]
    private Vector2 collapsed, expanded;

    [SerializeField]
    private Vector2 topPosition, bottomPosition;

    public void Expand(bool expanded)
    {
        StartCoroutine(Expand(expanded ? this.expanded : collapsed));
    }

    public void MoveY(bool up)
    {
        StartCoroutine(MoveY(up ? topPosition : bottomPosition));
    }

    private IEnumerator Expand(Vector2 targetSize)
    {
        Vector2 startSize = rect.sizeDelta;
        float t = 0;
        do
        {
            t += Time.deltaTime * moveSpeed;
            if (t > 1)
                t = 1;

            rect.sizeDelta = Vector2.LerpUnclamped(startSize, targetSize, Easing(t));
            yield return null;
        }
        while (t != 1);
    }
    private IEnumerator MoveY(Vector2 targetPosition)
    {
        Vector2 startPosition = rect.anchoredPosition;
        float t = 0;
        do
        {
            t += Time.deltaTime * moveSpeed;
            if (t > 1)
                t = 1;

            rect.anchoredPosition = Vector2.LerpUnclamped(startPosition, targetPosition, Easing(t));
            yield return null;
        }
        while (t != 1);
    }
}
