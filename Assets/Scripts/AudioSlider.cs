using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{

    [SerializeField]
    private AudioMixer Mixer;
    [SerializeField]
    private AudioSource AudioSource;
    [SerializeField]
    private AudioMixMode MixMode;
    

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume
    }

    public void OnChangeSlider(float Value)
    {
        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
            AudioSource.volume= Value;
            break;
            case AudioMixMode.LinearMixerVolume:
            Mixer.SetFloat("Volume" , (-80 + Value * 100));
            break;
            case AudioMixMode.LogrithmicMixerVolume:
            Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
            break;

        }

        PlayerPrefs.SetFloat("Volume" , Value);
        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    void Start()
    {
        Mixer.SetFloat("Volume" , Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20 ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
