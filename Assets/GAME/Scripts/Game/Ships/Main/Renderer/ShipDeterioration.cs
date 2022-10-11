using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class ShipDeterioration : MonoBehaviour
{
    [SerializeField] private Sprite[] _shipDeteriorationStagesSprites;

    private Sprite _fullHealthShipSprite;

    private SpriteRenderer _shipSpriteRenderer;

    private ShipHealthManager _shipHealthManager;

    private int _currentShipDeteriorationSpriteIndex;

    private void Awake()
    {
        _shipHealthManager = transform.parent.GetComponentInChildren<ShipHealthManager>();

        _shipSpriteRenderer = GetComponent<SpriteRenderer>();

        _fullHealthShipSprite = _shipSpriteRenderer.sprite;
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
        _shipSpriteRenderer.sprite = _shipDeteriorationStagesSprites[_currentShipDeteriorationSpriteIndex];

        if(_currentShipDeteriorationSpriteIndex < _shipDeteriorationStagesSprites.Length) _currentShipDeteriorationSpriteIndex++;
    }

    private void ResetShipDeteriorationValues()
    {
        _currentShipDeteriorationSpriteIndex = 0;
        _shipSpriteRenderer.sprite = _fullHealthShipSprite;
    }

    private void OnEnable() => ResetShipDeteriorationValues();
}
