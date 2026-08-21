using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionPanelUI : MonoBehaviour
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _mainMenuButon;
    [SerializeField] private Button _closeButton;


    [SerializeField] private SoundControlPanelUI _soundControlPanelUI;


    private void OnEnable()
    {
        _resumeButton.onClick.AddListener(ResumeButtonClick);
        _soundButton.onClick.AddListener(SoundButtonClick);
        _closeButton.onClick.AddListener(CloseButtonClick);
    }

  

    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(ResumeButtonClick);
        _soundButton.onClick.RemoveListener(SoundButtonClick);
        _closeButton.onClick.RemoveListener(CloseButtonClick);
    }

    private void Start()
    {
       
       
        GameManager.Instance.OnGamePauseChanged += Instance_OnGamePauseChanged;
        Hide();
    }

    private void ResumeButtonClick()
    {
        GameManager.Instance.Unpause();
    }
    private void CloseButtonClick()
    {
        GameManager.Instance.Unpause();
    }

    private void SoundButtonClick()
    {
        _soundControlPanelUI.Show();
    }
    private void Instance_OnGamePauseChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGamePaused)
        {
            Show();
            _soundControlPanelUI.Hide();
        }
        else
        {
            Hide();
        }
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
