using System.Threading.Tasks;
using UnityEngine;

public class AlphaTween : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    [SerializeField] private float _animationDuration = 1.5f;

    private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

    public void PlayFadeInAnimation()
    {
        _canvasGroup.alpha = 0f;
        LeanTween.alphaCanvas(_canvasGroup, 1f, _animationDuration).setIgnoreTimeScale(true);
    }

    public async void PlayFadeOutAnimation()
    {
        await Task.Delay(1000);
        _canvasGroup.alpha = 1f;
        LeanTween.alphaCanvas(_canvasGroup, 0f, _animationDuration);
    }
}
