using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private ScaleTween _gameResultsPanelTween;

    [SerializeField] private AlphaTween _fadeCanvasTween;

    private void Start()
    {
        GameManager.Instance.GameSessionManager.OnGameSessionEnds += _gameResultsPanelTween.PlayScaleInAnimation;
        _fadeCanvasTween.PlayFadeOutAnimation();
    }
}
