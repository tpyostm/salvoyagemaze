using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float blinkInterval = 0.5f;
    public float fadeTime = 0.5f;
    public Color blinkColor = Color.red;

    private Color originalColor;
    private float originalFontSize;

    private void Start()
    {
        originalColor = text.color;
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            // Fade in
            for (float t = 0.0f; t < fadeTime; t += Time.deltaTime)
            {
                float blend = Mathf.Clamp01(t / fadeTime);
                text.color = Color.Lerp(originalColor, blinkColor, blend);
                yield return null;
            }

            text.color = blinkColor;
            yield return new WaitForSeconds(blinkInterval / 2);

            // Fade out
            for (float t = 0.0f; t < fadeTime; t += Time.deltaTime)
            {
                float blend = Mathf.Clamp01(t / fadeTime);
                text.color = Color.Lerp(blinkColor, originalColor, blend);
                yield return null;
            }

            text.color = originalColor;
            yield return new WaitForSeconds(blinkInterval / 2);
        }
    }
}
