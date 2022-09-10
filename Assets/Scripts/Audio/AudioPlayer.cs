using UnityEngine.Audio;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;
    [SerializeField] private AudioMixerGroup _musicOutput;
    void Awake()
    {
        foreach (Sound s in _sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = _musicOutput;
        }
    }
    public void Play(string name)
    {
        foreach (Sound s in _sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
    public void Stop(string name)
    {
        foreach (Sound s in _sounds)
        {
            if (s.name == name)
                s.source.Stop();
        }
    }
    private void Start()
    {
        Play("Theme");
    }
}
