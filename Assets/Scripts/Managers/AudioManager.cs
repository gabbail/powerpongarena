using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioClip bgmClip;
    [SerializeField] private AudioClip buttonsClip;
    private AudioSource audioSource;
    private float sfxVolume = 1f;
    private float bgmVolume = 0.8f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true;
        audioSource.volume = bgmVolume;
    }

    private void Start()
    {
        audioSource.Play();
    }

    public void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, sfxVolume);
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonsClip, sfxVolume);
    }
}