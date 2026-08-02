using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameButton : MonoBehaviour
{


    [SerializeField] private Button _loadGameButton;

    [SerializeField] private TMP_Text _gameNameText;

    [SerializeField] private DoubleClickButton _deleteButton;

    private string _gameName;

    public void SetGameName(string gameName)
    {
        _gameName = gameName;

        _gameNameText.text = gameName;
    }


    private void Start()
    {
        _loadGameButton.onClick.AddListener(() =>
        {
            GameManager.Instance.LoadGame(_gameName);
        });

        _deleteButton.OnDoubleClick.AddListener(() =>
        {
            GameManager.Instance.DeleteSavedGames(_gameName);
            Destroy(gameObject);
        });
    }


}
