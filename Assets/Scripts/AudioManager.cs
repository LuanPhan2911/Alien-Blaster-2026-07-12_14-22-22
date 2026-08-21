using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{




    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource _musicAudioSource;

    [SerializeField] private AudioSource _audioSourcePrefab;

    private float _musicVolume=0.5f;
    private float _soundFxVolume=0.5f;

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

  

    public void Play(AudioClip audioClip, Vector3 position)
    {
        // Instantiate new audio source
        AudioSource audioSource = Instantiate(_audioSourcePrefab, position, Quaternion.identity);

        // assign audio clip and volume
        audioSource.clip= audioClip;
        audioSource.volume= _soundFxVolume;
        // play sound
        audioSource.Play();
        // get duration sound and destroy audio source
        float clipLength= audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength );
    }
    public void Play(AudioClip[] audioClips, Vector3 position)
    {
        AudioClip audioClip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        Play(audioClip, position);
    }

    
    public void PlayMusic(AudioClip audioClip)
    {
        _musicAudioSource.clip = audioClip;
    }
    public void SetMusicVolume(float volume)
    {
        _musicVolume= volume;
        _musicAudioSource.volume = volume;
    }
    public void SetSoundFxVolume(float volume)
    {
        _soundFxVolume= volume;
    }
    public float GetMusicVolume()
    {
        return _musicVolume;
    }
    public float GetSoundFxVolume()
    {
        return _soundFxVolume;
    }
   
}
