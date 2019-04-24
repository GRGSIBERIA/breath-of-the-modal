using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public float gain = 0.5F;

    private double sampleRate = 0.0F;
    public bool running = false;
    public double frequency = 440;
    private double phase = 0;

    public GameObject BlowerButton;
    public ButtonScript Blower { get; private set; }

    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        Blower = BlowerButton.GetComponent<ButtonScript>();
        running = false;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!running)
        {
            phase = 0;
            return;
        }

        double increment = frequency * 2 * Mathf.PI / sampleRate;
        const float PI = Mathf.PI;
        const float PI2 = Mathf.PI * 2;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase = phase + increment;

            double t = (phase + PI2) % PI2;
            data[i] = (float)(gain * ((t < PI ? t - PI : PI - t) / PI2 + 1.0));

            if (channels == 2) data[i + 1] = data[i];
            if (phase > 2 * Mathf.PI) phase = 0;
        }
    }

    public void SetTone(int n)
    {
        frequency = 440.0 * Mathf.Pow(2.0f, (n - 69) / 12.0f);
    }

    private void Update()
    {
        running = Blower.IsON() ? true : false;
    }
}