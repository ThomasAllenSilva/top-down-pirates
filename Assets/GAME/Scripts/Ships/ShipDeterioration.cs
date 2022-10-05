using UnityEngine;

public class ShipDeterioration : MonoBehaviour
{
    [SerializeField] private Sprite[] _shipDeteriorationStagesSprites;

    private SpriteRenderer _shipSpriteRenderer;

    private ShipHealthManager _shipHealthManager;

    private int curretnSprite;

    private void Awake()
    {
        _shipHealthManager = transform.parent.GetComponent<ShipHealthManager>();

        _shipSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() => _shipHealthManager.OnTakeDamage += CheckIfCanDeteriorateShip;
    

    private void CheckIfCanDeteriorateShip()
    {
        if (_shipHealthManager.ShipHealth % 2 == 0)
        {
            DeteriorateShip();
        }
        
    }

    private void DeteriorateShip()
    {
        _shipSpriteRenderer.sprite = _shipDeteriorationStagesSprites[curretnSprite];
        curretnSprite++;
    }
}
