using UnityEngine;

public class AudioManager : MonoBehaviour
{




    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _oneShotAuidoSource;
    [SerializeField] private AudioSource _loopAuidoSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }

        Instance = this;
        DontDestroyOnLoad(gameObject);






    }


    public void PlayOneShot(AudioClip audioClip)
    {
        _oneShotAuidoSource.PlayOneShot(audioClip);
    }
    public void Play(AudioClip audioClip)
    {
        if (_loopAuidoSource.isPlaying && _loopAuidoSource.clip == audioClip) return;
        _loopAuidoSource.clip = audioClip;
        _loopAuidoSource.Play();


    }
    public void Stop(AudioClip audioClip)
    {
        if (_loopAuidoSource.isPlaying && _loopAuidoSource.clip == audioClip)
        {
            _loopAuidoSource.clip = null;
            _loopAuidoSource.Stop();
        }
    }
}
