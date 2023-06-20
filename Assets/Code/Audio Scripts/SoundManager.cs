using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectSource;
    
    void Awake()
    {
        if (Instance == null)//tämä tekee Inctancen jokä säilyy
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else // ja jos instance in jo olemassa, tämä tuhoaa ylimääräisen
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }
}
