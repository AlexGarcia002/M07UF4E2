using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LSDVisionEffect : MonoBehaviour
{
    public PostProcessVolume volume;
    public float duration = 5f;

    private ChromaticAberration chroma;
    private ColorGrading colorGrade;
    private LensDistortion lensDistortion;

    private float timer = 0f;
    private bool isActive = false;

    void Start()
    {
        volume.profile.TryGetSettings(out chroma);
        volume.profile.TryGetSettings(out colorGrade);
        volume.profile.TryGetSettings(out lensDistortion);
    }

    public void ActivateEffect()
    {
        isActive = true;
        timer = 0f;
    }

    void Update()
    {
        if (!isActive) return;

        timer += Time.deltaTime;

        if (timer >= duration)
        {
            // Reset all effects to zero
            if (chroma != null) chroma.intensity.value = 0f;
            if (colorGrade != null)
            {
                colorGrade.saturation.value = 0f;
                colorGrade.hueShift.value = 0f;
                colorGrade.contrast.value = 0f;
            }
            if (lensDistortion != null) lensDistortion.intensity.value = 0f;

            isActive = false;
            return;
        }

        float pulseFast = Mathf.Sin(Time.time * 40f);      // Fast pulse
        float pingPong = Mathf.PingPong(Time.time * 8f, 1); // Smooth loop 0-1

        if (chroma != null)
            chroma.intensity.value = Mathf.Clamp01(Mathf.Abs(pulseFast)) * 1f;

        if (colorGrade != null)
        {
            colorGrade.saturation.value = Mathf.Lerp(-100f, 100f, pingPong);
            colorGrade.hueShift.value = Mathf.PingPong(Time.time * 300f, 360f); // Full hue rotation
            colorGrade.contrast.value = Mathf.Sin(Time.time * 10f) * 100f;
        }

        if (lensDistortion != null)
            lensDistortion.intensity.value = Mathf.Sin(Time.time * 6f) * 80f; // Wavy distortion
    }
}
