using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public BulletsObjectPool BulletsObjectPool { get; private set; }

    public ExplosionsEffectObjectPool ExplosionsEffectObjectPool { get; private set; }

    public ShipDeathAnimationEffectObjectPool ShipDeathAnimationEffectObjectPool { get; private set; }

    public EnemiesShipsObjectPooler EnemiesShipsObjectPooler { get; private set; }

    public EnemiesSpawner EnemiesSpawner { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        BulletsObjectPool = GetComponentInChildren<BulletsObjectPool>();

        ExplosionsEffectObjectPool = GetComponentInChildren<ExplosionsEffectObjectPool>();

        ShipDeathAnimationEffectObjectPool = GetComponentInChildren<ShipDeathAnimationEffectObjectPool>();

        EnemiesShipsObjectPooler = GetComponentInChildren<EnemiesShipsObjectPooler>();

        EnemiesSpawner = GetComponentInChildren<EnemiesSpawner>();
    }
}
