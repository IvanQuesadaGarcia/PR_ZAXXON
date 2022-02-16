using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigScript : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameManager.musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.musicVolume = volumeSlider.value;
    }
}
