using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private Animator _explosionAnimator;

    private void Awake() => _explosionAnimator = GetComponent<Animator>();

    public void SetExplosionEffectScale(float explosionEffectScale)
    {
        transform.localScale = Vector3.one * explosionEffectScale;
    }

    public void DisableThisExplosionEffect()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _explosionAnimator.Play("ExplosionEffect");
    }
}
