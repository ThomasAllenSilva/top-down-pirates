using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public BulletsObjectPool BulletsObjectPool { get; private set; }

    public ExplosionsEffectObjectPool ExplosionsEffectObjectPool { get; private set; }

    public ShipDeathAnimationEffectObjectPool ShipDeathAnimationEffectObjectPool { get; private set; }

    public EnemiesShipsObjectPooler EnemiesShipsObjectPooler { get; private set; }

    public EnemiesSpawner EnemiesSpawner { get; private set; }

    public PlayerPointsManager PlayerPointsManager { get; private set; }

    public GameSessionManager GameSessionManager { get; private set; }

    public bool GameIsRunning { get; private set; } = true;

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

        PlayerPointsManager = GetComponentInChildren<PlayerPointsManager>();

        GameSessionManager = GetComponentInChildren<GameSessionManager>();
    }

    private void Start() => GameSessionManager.OnGameSessionEnds += StopGame;
    
    private void StopGame()
    {
        GameIsRunning = false;
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        if(GameSessionManager != null) GameSessionManager.OnGameSessionEnds -= StopGame;
    }
}
