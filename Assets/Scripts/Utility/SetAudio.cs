using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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

        if (audioMixer.GetFloat("masterVolume", out float value))
            master.value = value;

        if (audioMixer.GetFloat("musicVolume", out value))
            music.value = value;

        if (audioMixer.GetFloat("sfxVolume", out value))
            effects.value = value;
    }
    public void SetMasterVolume()
    {
        audioMixer.SetFloat("masterVolume", master.value);
    }
    public void SetMusicVolume()
    {
        audioMixer.SetFloat("musicVolume", music.value);
    }
    public void SetEffectsVolume()
    {
        audioMixer.SetFloat("sfxVolume", effects.value);
    }
}
