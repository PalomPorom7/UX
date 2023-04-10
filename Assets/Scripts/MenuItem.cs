using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    [SerializeField]
    private Vector2 hiddenPosition, shownPosition;

    [SerializeField]
    protected float moveSpeed = 1;

    protected RectTransform rect;

    protected void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void Hide(bool hidden)
    {
        StartCoroutine(Move(hidden ? hiddenPosition : shownPosition));
    }

    protected IEnumerator Move(Vector2 targetPosition)
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

    protected float Easing(float t)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1;

        return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
    }
}
