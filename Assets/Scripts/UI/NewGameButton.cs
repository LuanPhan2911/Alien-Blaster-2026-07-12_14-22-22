using UnityEngine;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{

    [SerializeField] private Button _newGameButton;



    private void Start()
    {
        _newGameButton.onClick.AddListener(OnNewGameButtonClicked);
    }

    private void OnNewGameButtonClicked()
    {
        GameManager.Instance.NewGame();
    }
}
