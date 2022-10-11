using UnityEngine;
using TMPro;

public class PlayerResultsManager : MonoBehaviour
{
    private TextMeshProUGUI _playerPointsText;

    private void Awake() => _playerPointsText = GetComponentInChildren<TextMeshProUGUI>();

    private void Start() => GameManager.Instance.GameSessionManager.OnGameSessionStopped += ShowPlayerPointsInTheResultsText;

    private void ShowPlayerPointsInTheResultsText()
    {
        _playerPointsText.text += GameManager.Instance.PlayerPointsManager.PlayerPoints;
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null) GameManager.Instance.GameSessionManager.OnGameSessionStopped -= ShowPlayerPointsInTheResultsText; 
    }
}
