using UnityEngine;
using TMPro;

public class PlayerResultsManager : MonoBehaviour
{
    private TextMeshProUGUI _playerPointsText;

    private void Awake() => _playerPointsText = GetComponentInChildren<TextMeshProUGUI>();

    private void Start() => GameManager.Instance.GameSessionManager.OnGameSessionEnds += ShowPlayerPointsInTheResultsText;

    private void ShowPlayerPointsInTheResultsText()
    {
        _playerPointsText.text += GameManager.Instance.PlayerPointsManager.PlayerPoints;
    }
}
