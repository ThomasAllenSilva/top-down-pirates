using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [field: SerializeField] public AlphaTween FadeCanvasTween { get; private set; }

    [SerializeField] private ScaleTween _gameResultsPanelTween;

    private void Start() => GameManager.Instance.GameSessionManager.OnGameSessionStopped += _gameResultsPanelTween.PlayScaleInAnimation;
}
