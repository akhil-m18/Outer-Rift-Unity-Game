using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PressAnyButtonFade : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * fadeSpeed) + 1f) / 2f;
        canvasGroup.alpha = Mathf.Lerp(minAlpha, maxAlpha, t);
    }
}