using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    
    

    [Header("--------- Audio Clip ------")]
    public AudioClip background;
    public AudioClip click;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    // Efeitos sonoros
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    } 
    public static AudioManager instace;
    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    internal void PlayClick()
    {
        throw new NotImplementedException();
    }
}

  