using UnityEngine;
using UnityEngine.UI;

public class SavedGameUI : MonoBehaviour
{


    [SerializeField] private LoadGameButton _loadGameButtonPrefab;


    [SerializeField] private Transform _buttonContainerTransform;

    [SerializeField] private Button _backButton;


    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {

        _backButton.onClick.AddListener(() =>
        {
            Hide();
        });

        foreach (var savedGame in GameManager.Instance.GameNameList)
        {
            LoadGameButton loadGameButton = Instantiate(_loadGameButtonPrefab, _buttonContainerTransform);
            loadGameButton.SetGameName(savedGame);
        }
        Hide();
    }
}
