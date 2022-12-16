using System.Collections;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    // The duration of the fade in
    public float fadeDuration = 1.0f;

    // The color of the fade
    public Color fadeColor = Color.black;

    void Start()
    {
        // Start the fade in
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // Create a texture to use for the fade
        Texture2D fadeTexture = new Texture2D(1, 1);
        fadeTexture.SetPixel(0, 0, fadeColor);
        fadeTexture.Apply();

        // Create a rect with the texture to use for the fade
        Rect fadeRect = new Rect(0, 0, Screen.width, Screen.height);

        // Set the start time
        float startTime = Time.time;

        // Set the fade alpha to 1
        float fadeAlpha = 1.0f;

        // Fade in
        while (Time.time < startTime + fadeDuration)
        {
            // Calculate the fade alpha value
            fadeAlpha = Mathf.Clamp01(1.0f - (Time.time - startTime) / fadeDuration);

            // Draw the fade texture on screen with the calculated alpha value
            GUI.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeAlpha);
            GUI.DrawTexture(fadeRect, fadeTexture);

            yield return null;
        }
    }
}

