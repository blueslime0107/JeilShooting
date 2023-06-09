using UnityEngine.Audio;
using System;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    public int group;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
    [HideInInspector]
    public AudioReverbFilter reverb;
}

public class SoundManager : MonoBehaviour
{
    public string startSound;
    public Sound[] sounds;
    public Sound[] musics;
    public AudioMixerGroup[] mixer;

    
    

    void Awake()
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mixer[s.group];
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;

        }
        foreach(Sound s in musics){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mixer[s.group];
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;

        }
    }

    void Start(){
        if(startSound == ""){return;}
        Play(startSound);
    }

    public void Play(string name){
        try
        {Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
        if(s == null){
            Debug.Log("Sound Missing");
            return;
            }
        s.source.Play();}
        catch{
            Debug.Log("Play Error!");
        }
    }

    public void PlayBGM(string name){
        try
        {Sound s = Array.Find(musics, sound => sound.name.Equals(name));
        if(s == null){
            Debug.Log("Sound Missing");
            return;
            }
        s.source.Play();}
        catch{
            Debug.Log("Play Error!");
        }
    }
}
