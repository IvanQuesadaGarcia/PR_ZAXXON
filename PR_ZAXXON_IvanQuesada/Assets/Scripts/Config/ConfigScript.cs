using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class ConfigScript : MonoBehaviour
{
    [SerializeField] string volumeParameter = "MasterVol";
    [SerializeField] string musicParameter = "MusicVol";
    [SerializeField] string sfxParameter = "SFXVol";

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [SerializeField] AudioMixer masterMixer;

    [SerializeField] float multiplier = 30f;

    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(CambiarVolumen);
        musicSlider.onValueChanged.AddListener(CambiarVolMusic);
        sfxSlider.onValueChanged.AddListener(CambiarVolSFX);
    }	

	private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, volumeSlider.value);
        PlayerPrefs.SetFloat(musicParameter, musicSlider.value);
        PlayerPrefs.SetFloat(sfxParameter, sfxSlider.value);
    }

	private void CambiarVolumen(float value)
	{
        masterMixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
	}
    private void CambiarVolMusic(float value)
    {
        masterMixer.SetFloat(musicParameter, Mathf.Log10(value) * multiplier);
    }
    private void CambiarVolSFX(float value)
    {
        masterMixer.SetFloat(sfxParameter, Mathf.Log10(value) * multiplier);
    }

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(volumeParameter, volumeSlider.value);
        musicSlider.value = PlayerPrefs.GetFloat(musicParameter, musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat(sfxParameter, sfxSlider.value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
