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
    }
    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(ResumeButtonClick);
        _closeButton.onClick.RemoveListener(CloseButtonClick);
    }
    private void Start()
    {
        Hide();
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
