using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //[SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip moveTile;

    private void Start()
    {
        // Play the background music
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
