using UnityEngine;

public class KamikazeFlash : MonoBehaviour
{
    public float flashSpeed = 5f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        float flash = (Mathf.Sin(Time.time * flashSpeed) + 1f) / 2f;

        spriteRenderer.color = Color.Lerp(
            originalColor,
            Color.red,
            flash * 0.6f
        );
    }
}