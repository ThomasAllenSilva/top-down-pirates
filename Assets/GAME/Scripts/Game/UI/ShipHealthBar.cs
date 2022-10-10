using UnityEngine;
using UnityEngine.UI;

public class ShipHealthBar : MonoBehaviour
{
    private Image _shipHealthBarImage;

    private ShipHealthManager _shipHealthManager;

    private void Awake()
    {
        _shipHealthBarImage = GetComponent<Image>();
        _shipHealthManager = transform.parent.parent.GetComponent<ShipHealthManager>();
    }

    private void Start()
    {
        _shipHealthManager.OnTakeDamage += FillOutShipHealthBarImage;
    }

    private void FillOutShipHealthBarImage()
    {
        float healthFillPercent = (float) _shipHealthManager.CurrentShipHealth / _shipHealthManager.ShipMaxHealth;
        _shipHealthBarImage.fillAmount = healthFillPercent;
    }

    private void ResetHealthBarUIImageFillAmount()
    {
        _shipHealthBarImage.fillAmount = 1f;
    }

    private void OnEnable()
    {
        ResetHealthBarUIImageFillAmount();
    }

    private void OnDestroy()
    {
        if (_shipHealthManager != null)
        {
            _shipHealthManager.OnTakeDamage -= FillOutShipHealthBarImage;
        }
    }
}
