using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public BulletsObjectPool BulletsObjectPool { get; private set; }

    public ExplosionsEffectObjectPool ExplosionsEffectObjectPool { get; private set; }

    public ShipDeathAnimationEffectObjectPool ShipDeathAnimationEffectObjectPool { get; private set; }

    public EnemiesShipsObjectPooler EnemiesShipsObjectPooler { get; private set; }

    public EnemiesSpawnerManager EnemiesSpawner { get; private set; }

    public PlayerPointsManager PlayerPointsManager { get; private set; }

    public GameSessionManager GameSessionManager { get; private set; }

    public CanvasManager CanvasManager { get; private set; }

    public bool GameIsRunning { get; private set; } = true;

    private void Awake()
    {
        Time.timeScale = 1;

        if (Instance == null)
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

        EnemiesSpawner = GetComponentInChildren<EnemiesSpawnerManager>();

        PlayerPointsManager = GetComponentInChildren<PlayerPointsManager>();

        GameSessionManager = GetComponentInChildren<GameSessionManager>();

        CanvasManager = GetComponentInChildren<CanvasManager>();
    }

    private void Start() => GameSessionManager.OnGameSessionStopped += StopGame;
    
    private void StopGame()
    {
        GameIsRunning = false;
    }

    public void ApplyGameOptions(int gameSessionTime, float enemiesSpawnTime)
    {
        GameSessionManager.SetGameSessionTime(gameSessionTime);
        EnemiesSpawner.SetDelayToSpawnEnemies(enemiesSpawnTime);
    }

    private void OnDestroy()
    {
        if(GameSessionManager != null) GameSessionManager.OnGameSessionStopped -= StopGame;
    }
}
