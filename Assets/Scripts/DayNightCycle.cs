using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public GameManager gameManager; 
    
    public float dayDuration = 600f; // 10 minutes in seconds
    public Light directionalLight;
    public Color dayColor = new Color(1f, 1f, 0.75f);
    public Color nightColor = new Color(0.05f, 0.05f, 0.2f);
    public float dayIntensity = 1f;
    public float nightIntensity = 0.5f;

    public float elapsedTime = 0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // Calculate the lerp value between day and night based on elapsed time
        float lerpValue = Mathf.Clamp01(elapsedTime / dayDuration);

        // Update directional light color and intensity
        directionalLight.color = Color.Lerp(dayColor, nightColor, lerpValue);
        directionalLight.intensity = Mathf.Lerp(dayIntensity, nightIntensity, lerpValue);

        // You can add more effects or adjustments here based on the time of day

        if (elapsedTime >= dayDuration)
        {
            // Reset elapsed time to start the cycle again
            elapsedTime = 0f;
            gameManager.NewDay();
        }
    }
}