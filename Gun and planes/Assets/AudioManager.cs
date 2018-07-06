using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public bool wlacz;
    [SerializeField]
    Sound[] sounds;
    public bool SoundON;
   

    
    private void Awake()
    {
        if (instance!=null)
        {
            if (instance!=this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        
    }
    void Start()
    {
        AudioPausedIsNotTrue();
        SoundON = true;  
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_"+i+"_"+sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
          
        }
    }
    public void AudioPausedIsTrue()
    {
        AudioListener.pause = true;
    }
    public void AudioPausedIsNotTrue()
    {
        AudioListener.pause = false;
    }
    public void PlaySound(string _name)
    {
        if (SoundON==true)
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                if (sounds[i].name == _name)
                {
                    sounds[i].Play();
                    return;
                }
            }
            Debug.LogWarning("Audio manager sound doesn't find this audio source: " + _name);
        }
        else { }
       
    }
    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }
        Debug.LogWarning("Audio manager sound doesn't find this audio source: " + _name);
    }
    public void StopAllSounds()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
        }
    }
   
}
[System.Serializable]
public class Sound
    {
        public string name;
        public AudioClip clip;
    public bool loop = false;
        private AudioSource source;
    [Range(0.5f, 1.5f)]
    public float pitch=0.7f;
    [Range(0f, 1f)]
    public float volume=1f;
    [Range(0f,0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f,0.5f)]
    public float randomPitch = 0.1f;
        public void SetSource(AudioSource _source)
        {
            source = _source;
            source.clip = clip;
        source.loop = loop;
        }
        public void Play()
        {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
            source.Play();
        }
    
    public void ChangeVolume(float volume)
    {
        source.volume = volume;
    }
    public void Stop()
    {
       
        source.Stop();
    }
}

