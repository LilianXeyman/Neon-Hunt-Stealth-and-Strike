using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    [SerializeField]
    float valueVolume;
    [SerializeField]
    Slider slideVolume;
    [SerializeField]
    Image imageMuteO;

    // Start is called before the first frame update
    void Start()
    {
        slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slideVolume.value;
        Mute();
    }

    // Update is called once per frame
    void Update()
    {
        slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slideVolume.value;
        Mute();
    }
    public void VolumenSlide(float valor)
    {
        valueVolume = valor;
        PlayerPrefs.SetFloat("volumenAudio", valueVolume);
        AudioListener.volume = valueVolume;
        Mute();
    }

    public void Mute()
    {
        if (valueVolume == 0)
        {
            imageMuteO.enabled = true;
            //imageMuteG.enabled = true;
        }
        else
        {
            imageMuteO.enabled = false;
            //imageMuteG.enabled = false;
        }
    }
}
