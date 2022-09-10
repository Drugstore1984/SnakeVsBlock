using UnityEngine;
using UnityEngine.Audio;

public class AudioOnOff : MonoBehaviour
{
    [SerializeField] GameObject _onButton,_offButton;
    [SerializeField] private AudioMixer _audioMixer;
    private float minAttenuation = -80.0f;
    private float maxAttenuation = 0.0f;
    private string mixerParameter = "MainVolume";
    private string audioMute = "AudioMute";
    private void Awake()
    {
        if (PlayerPrefs.GetInt(audioMute) == 1)
        {
            OffAudio();
        }
        else
        {
            OnAudio();
        }
    }
    public void OffAudio()
    {
        _audioMixer.SetFloat(mixerParameter, minAttenuation);
        _offButton.SetActive(true);
        _onButton.SetActive(false);
        PlayerPrefs.SetInt(audioMute, 1);
        PlayerPrefs.Save();
    }
    public void OnAudio()
    {
        _audioMixer.SetFloat(mixerParameter, maxAttenuation);
        _offButton.SetActive(false);
        _onButton.SetActive(true);
        PlayerPrefs.SetInt(audioMute, 0);
        PlayerPrefs.Save();
    }
}
