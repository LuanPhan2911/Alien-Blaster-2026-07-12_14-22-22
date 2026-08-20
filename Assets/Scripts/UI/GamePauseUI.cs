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


   

    private void Start()
    {
        _resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.Unpause();
        });
        _soundButton.onClick.AddListener(() =>
        {
            _soundControlPanelUI.Show();
        });

        _closeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.Unpause();
        });
        GameManager.Instance.OnGamePauseChanged += Instance_OnGamePauseChanged;
        Hide();
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
