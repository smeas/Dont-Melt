using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Robin + Jonatan
public class SetAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [Header("Sliders")]
    [SerializeField] private Slider master;
    [SerializeField] private Slider music;
    [SerializeField] private Slider effects;

    private void Start()
    {
        if (audioMixer == null)
            Debug.LogError("Missing Audio Mixer");

        SetLinearVolume("masterVolume", master.value = PlayerPrefs.GetFloat("masterVolume", 1));
        SetLinearVolume("musicVolume", music.value = PlayerPrefs.GetFloat("musicVolume", 1));
        SetLinearVolume("sfxVolume", effects.value = PlayerPrefs.GetFloat("sfxVolume", 1));
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("masterVolume", master.value);
        PlayerPrefs.SetFloat("musicVolume", music.value);
        PlayerPrefs.SetFloat("sfxVolume", effects.value);
        PlayerPrefs.Save();
    }

    public void SetMasterVolume()
    {
        SetLinearVolume("masterVolume", master.value);
    }

    public void SetMusicVolume()
    {
        SetLinearVolume("musicVolume", music.value);
    }

    public void SetEffectsVolume()
    {
        SetLinearVolume("sfxVolume", effects.value);
    }

    private float GetLinearVolume(string groupName)
    {
        if (audioMixer.GetFloat(groupName, out float value))
            return DecibelsToLinear(value);
        return 1;
    }

    private void SetLinearVolume(string groupName, float value)
    {
        audioMixer.SetFloat(groupName, LinearToDecibels(value));
    }


    //  20 dB <=> 10
    //   0 dB <=> 1
    // -80 dB <=> 0.0001
    // https://en.wikipedia.org/wiki/Decibel
    private static float DecibelsToLinear(float db)
    {
        return Mathf.Pow(10, db / 20);
    }

    private static float LinearToDecibels(float linear)
    {
        const float min = 0.0001f;
        if (linear < min)
            linear = min;

        return 20 * Mathf.Log10(linear);
    }
}
