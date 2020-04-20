using UnityEngine;

public class VolumeValueChange : MonoBehaviour {


    private AudioSource audioSrc;

    // Music volume variable that will be modified
    // by dragging slider
    public static float musicVolume = 1f;

	
	void Start () {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
	}
	
	
	void Update () {

        // Setting volume option to be equal to musicVolume
        audioSrc.volume = musicVolume;
	}

    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

}

