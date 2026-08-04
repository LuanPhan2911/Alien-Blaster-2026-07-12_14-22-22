using UnityEngine;

public class PlayerLoopSound : MonoBehaviour
{

    [SerializeField] private AudioSource _loopAudioSource;


    [SerializeField] private AudioClip _walkingSound;
    [SerializeField] private AudioClip _swimmingSound;

    private void Start()
    {
        _loopAudioSource.enabled = false;
    }
    public void PlaySwimmingSound()
    {
        _loopAudioSource.clip = _swimmingSound;

        _loopAudioSource.enabled = true;
    }

    public void PlayWalkingSound()
    {
        _loopAudioSource.clip = _walkingSound;

        _loopAudioSource.enabled = true;
    }
    public void Stop()
    {
        _loopAudioSource.clip = null;
        _loopAudioSource.enabled = false;
    }
}
