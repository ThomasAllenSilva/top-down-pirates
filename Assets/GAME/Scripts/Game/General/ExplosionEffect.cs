using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private Animator _explosionAnimator;

    private const string ExplosionEffectAnimationName = "ExplosionEffect";

    private void Awake() => _explosionAnimator = GetComponent<Animator>();

    public void DisableThisExplosionEffect()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _explosionAnimator.Play(ExplosionEffectAnimationName);
    }
}
