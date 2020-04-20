using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip gameMusic;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayOneShot(gameMusic);
    }

   
    // == public methods ==
    //plays clip once
    public void PlayOneShot(AudioClip clip)
    {
        if(clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
    //turns all sounds on/off
    public void ToggleSounds()
    {
       
        //Debug.Log("Inside ToggleSounds right now");
        AudioListener.pause=!AudioListener.pause;
        
    }

    public static MusicPlayer FindMusicPlayer()
    {
        MusicPlayer mp = FindObjectOfType<MusicPlayer>();
        if(!mp)
        {
            Debug.LogWarning("Missing MusicPlayer");
        }
        return mp;
    }


}
