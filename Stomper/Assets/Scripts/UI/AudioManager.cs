using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource;
    public AudioClip musicClip;
    public AudioClip jumpSound;
    public AudioClip doorSound;
    public AudioClip pickSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(musicSource != null && musicClip != null)
        {
           musicSource.clip = musicClip;
           musicSource.loop = true;
           musicSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        if(jumpSound != null)
        {
            musicSource.PlayOneShot(jumpSound);
        }
    }

    public void PlayDoorSound()
    {
        if(doorSound != null)
        {
            musicSource.PlayOneShot(doorSound);
        }
    }

    public void PlayPickSound()
    {
        if(pickSound != null)
        {
            musicSource.PlayOneShot(pickSound);
        }
    }
}