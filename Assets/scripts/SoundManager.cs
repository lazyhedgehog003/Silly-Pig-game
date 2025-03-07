using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip hopSound;
    public AudioClip collisionsound;
    public AudioClip GameOver;
    
    public void PlayHopSound()
    {
        audiosource.PlayOneShot(hopSound);
    }
    public void PlayCollisionSound()
    {
        audiosource.PlayOneShot(collisionsound);
    }
    public void PlayGameOver()
    {
        audiosource.PlayOneShot(GameOver);
    }
}
