using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundControlPanelUI : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundFxSlider;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _closeButton;


    private void OnEnable()
    {
        _resumeButton.onClick.AddListener(ResumeButtonClick);
        _closeButton.onClick.AddListener(CloseButtonClick);
        _musicSlider.onValueChanged.AddListener(MusicSliderChange);
        _soundFxSlider.onValueChanged.AddListener(SoundFxSliderChange);
    }
    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(ResumeButtonClick);
        _closeButton.onClick.RemoveListener(CloseButtonClick);
        _musicSlider.onValueChanged.RemoveListener(MusicSliderChange);
        _soundFxSlider.onValueChanged.RemoveListener(SoundFxSliderChange);
    }
    private void Start()
    {
        _musicSlider.value= AudioManager.Instance.GetMusicVolume();
        _soundFxSlider.value= AudioManager.Instance.GetSoundFxVolume();
        
        Hide();
    }
    private void MusicSliderChange(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }
    private void SoundFxSliderChange(float value)
    {
        AudioManager.Instance.SetSoundFxVolume(value);
    }
    private void CloseButtonClick()
    {
        Hide();
    }

    private void ResumeButtonClick()
    {
        GameManager.Instance.Unpause();
    }

    

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
