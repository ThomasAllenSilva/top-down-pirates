using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private ScaleTween _gameResultsPanelTween;

    [field: SerializeField] public AlphaTween FadeCanvasTween { get; private set; }

    private void Start()
    {
        FadeCanvasTween.PlayFadeOutAnimation();

        GameManager.Instance.GameSessionManager.OnGameSessionEnds += _gameResultsPanelTween.PlayScaleInAnimation;
    }
}
