using UnityEngine;
using UnityEngine.UI;

public class LoadGameButton : MonoBehaviour
{


    [SerializeField] private Button _loadGameButton;


    private void Start()
    {
        _loadGameButton.onClick.AddListener(OnLoadGameButtonClicked);
    }

    private void OnLoadGameButtonClicked()
    {
        GameManager.Instance.LoadGame();
    }
}
