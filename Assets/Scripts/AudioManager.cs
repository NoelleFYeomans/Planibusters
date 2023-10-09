using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider; //this is for saving volume

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("audioVolume"))
        {
            PlayerPrefs.SetFloat("audioVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("audioVolume");
    }

    private void Save() //saved to PlayerPrefs because audio doesn't need to be protected
    {
        PlayerPrefs.SetFloat("audioVolume", volumeSlider.value);
    }
}
