using UnityEngine.Audio;
using System;
using UnityEngine;

//Credit to Brackeys youtube tutorial on Audio managers, as the majority of this code and learning how to use it was made by him.
// Alla se skripti joka pitää liittää sinne paikkaan koodia mistä ääntä haluaa kuulla
//FindObjectOfType<AudioManagerScript>().Play("Shoot!");
//FindObjectOfType<AudioManagerScript>().Stop("Shoot!"); luultavasti lopettaa musiikin/äänen.

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    public Sound[] sounds;

    public static AudioManagerScript instance;
    //AudioManager

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //Play("Theme");
      
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}