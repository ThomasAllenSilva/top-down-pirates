using UnityEngine;

public class ShipDeterioration : MonoBehaviour
{
    [SerializeField] private Sprite[] _shipDeteriorationStagesSprites;

    private SpriteRenderer _shipSpriteRenderer;

    private Sprite _defaultShipSprite;

    private ShipHealthManager _shipHealthManager;

    private int _currentShipDeteriorationSprite;

    private void Awake()
    {
        _shipHealthManager = transform.parent.GetComponentInChildren<ShipHealthManager>();

        _shipSpriteRenderer = GetComponent<SpriteRenderer>();

        _defaultShipSprite = _shipSpriteRenderer.sprite;
    }

    private void Start() => _shipHealthManager.OnTakeDamage += CheckIfCanDeteriorateShip;

    private void CheckIfCanDeteriorateShip()
    {
        if (_shipHealthManager.CurrentShipHealth % 2 == 0)
        {
            DeteriorateShip();
        }
    }

    private void DeteriorateShip()
    {
        _shipSpriteRenderer.sprite = _shipDeteriorationStagesSprites[_currentShipDeteriorationSprite];
        _currentShipDeteriorationSprite++;
    }

    private void ResetShipDeteriorationValues()
    {
        _currentShipDeteriorationSprite = 0;
        _shipSpriteRenderer.sprite = _defaultShipSprite;
    }

    private void OnEnable()
    {
        ResetShipDeteriorationValues();
    }
}
