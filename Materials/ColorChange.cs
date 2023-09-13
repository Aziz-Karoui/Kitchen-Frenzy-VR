using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material targetMaterial;
    public Color[] colors;
    public float duration = 5f;

    private int currentIndex;
    private float startTime;

    private void Start()
    {
        currentIndex = 0;
        startTime = Time.time;
    }

    private void Update()
    {
        float t = (Time.time - startTime) / duration;
        Color startColor = colors[currentIndex];
        Color endColor = colors[(currentIndex + 1) % colors.Length];
        Color lerpedColor = Color.Lerp(startColor, endColor, t);
        lerpedColor.a = 220f / 255f; // Set transparency to 220 (out of 255)
        targetMaterial.color = lerpedColor;

        if (t >= 1f)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            startTime = Time.time;
        }
    }
}
