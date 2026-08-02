using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameButton : MonoBehaviour
{


    [SerializeField] private Button _loadGameButton;

    [SerializeField] private TMP_Text _gameNameText;

    private string _gameName;

    public void SetGameName(string gameName)
    {
        _gameName = gameName;

        _gameNameText.text = gameName;
    }


    private void Start()
    {
        _loadGameButton.onClick.AddListener(OnLoadGameButtonClicked);
    }

    private void OnLoadGameButtonClicked()
    {
        GameManager.Instance.LoadGame(_gameName);
    }
}
