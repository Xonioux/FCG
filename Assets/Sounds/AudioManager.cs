using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake (){
        
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

    //IF I WANT TO PLAY SOMETHING ALL THE TIME PUT IT HERE//

    void Start()
    {
        Play("Crowd Sound");
    }



    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        
        s.source.Play();
        
    }

}


//Notes for meself, use the line: 

//  FindObjectOfType<AudioManager>().Play("Anthem");

//and you'll be all set