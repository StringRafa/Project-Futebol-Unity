using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Musicas
    public AudioClip[] clips;
    public AudioSource musicaBG;
    //SonsFX
    public AudioClip[] clipsFX;
    public AudioSource sonsFX;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        if (!musicaBG.isPlaying)
        {
            musicaBG.clip = GetRandom();
            musicaBG.Play();
        }
    }

    AudioClip GetRandom()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    public void SonsFXToca(int index)
    {
        sonsFX.clip = clipsFX[index];
        sonsFX.Play();
    }

}
