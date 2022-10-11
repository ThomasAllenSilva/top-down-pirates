using UnityEngine;

public class EndSessionPanelButtonEvents : MonoBehaviour
{
    public void BackToMainMenuButton()
    {
        GameManager.Instance.CanvasManager.FadeCanvasTween.PlayFadeInAnimationAndLoadScene(0);
        Time.timeScale = 1;
    }

    public void PlayAgainButton()
    {
        GameManager.Instance.CanvasManager.FadeCanvasTween.PlayFadeInAnimationAndLoadScene(1);
    }
}
