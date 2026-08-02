using UnityEngine;

public class SavedGameUI : MonoBehaviour
{


    [SerializeField] private LoadGameButton _loadGameButtonPrefab;


    [SerializeField] private Transform _buttonContainerTransform;
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

        foreach (var savedGame in GameManager.Instance.GameNameList)
        {
            LoadGameButton loadGameButton = Instantiate(_loadGameButtonPrefab, _buttonContainerTransform);
            loadGameButton.SetGameName(savedGame);
        }
        Hide();
    }
}
