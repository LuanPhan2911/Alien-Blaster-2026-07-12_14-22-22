using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{


    [SerializeField] private TMP_Text _scoreText;




    private void OnEnable()
    {
        Player.OnCoinChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        Player.OnCoinChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(object sender, int coin)
    {
        _scoreText.text = $"{coin}";
    }
}
