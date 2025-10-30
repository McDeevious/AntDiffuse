using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    public AudioClip moveTile;
    public AudioClip wireSnip;
    public AudioClip keypad;
    public AudioClip pipeMove;
    public AudioClip button;

    private void Start()
    {
        // Play the background music
        musicSource.volume = 0.025f;
        musicSource.loop = true;
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
