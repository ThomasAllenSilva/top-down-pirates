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

    private void OnDisable()
    {
        _shipHealthManager.OnTakeDamage -= FillOutShipHealthBarImage;
    }
}
