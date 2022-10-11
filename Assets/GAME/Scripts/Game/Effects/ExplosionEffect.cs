using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ExplosionEffect : MonoBehaviour
{
    private Animator _explosionEffectAnimator;

    private const string ExplosionEffectAnimationName = "ExplosionEffect";

    private void Awake() => _explosionEffectAnimator = GetComponent<Animator>();

    public void DisableThisExplosionEffect()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable() => _explosionEffectAnimator.Play(ExplosionEffectAnimationName);
}
