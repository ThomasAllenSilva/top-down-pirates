using UnityEngine;

public class ShipDeterioration : MonoBehaviour
{
    [SerializeField] private Sprite[] _shipDeteriorationStagesSprites;

    private ShipHealthManager _shipHealthManager;

    private void Awake()
    {
        _shipHealthManager = transform.parent.GetComponent<ShipHealthManager>();
    }
    private void Start()
    {
        _shipHealthManager.OnTakeDamage += CheckIfCanDeteriorateShip;
    }

    private void CheckIfCanDeteriorateShip()
    {
        if(_shipHealthManager.ShipHealth <= 10)
        {
            DeteriorateShip();
        }
    }

    private void DeteriorateShip()
    {
        GetComponent<SpriteRenderer>().sprite = _shipDeteriorationStagesSprites[0];
    }
}
