using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ShipDeathAnimationEffect : MonoBehaviour
{
    private Animator _shipAnimator;

    private const string ShipDeathAnimationName = "ShipDeathAnimationEffect";

    private void Awake() => _shipAnimator = GetComponent<Animator>();

    public void DisableThisShipDeathAnimationEffect()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable() => _shipAnimator.Play(ShipDeathAnimationName);
}
