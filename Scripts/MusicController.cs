using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () 
    {
        MakeSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(bool play)
    {
        if (play)
        {
            IGTLGamePreferences.SetMusicState(1);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            IGTLGamePreferences.SetMusicState(0);
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
