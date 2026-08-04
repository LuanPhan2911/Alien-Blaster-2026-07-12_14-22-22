using UnityEngine;

public class PlayerOneShotSound : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;



    public void Play(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;

        _audioSource.Play();
    }
}
