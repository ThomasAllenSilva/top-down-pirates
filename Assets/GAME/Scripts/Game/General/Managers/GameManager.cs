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

        EnemiesSpawner = GetComponentInChildren<EnemiesSpawner>();

        PlayerPointsManager = GetComponentInChildren<PlayerPointsManager>();

        GameSessionManager = GetComponentInChildren<GameSessionManager>();

        CanvasManager = GetComponentInChildren<CanvasManager>();
    }

    
    private void Start() => GameSessionManager.OnGameSessionEnds += StopGame;
    
    private void StopGame()
    {
        GameIsRunning = false;
        Time.timeScale = 0;
    }

    public void ApplyPlayerGameOptions(int gameSessionTime, float enemiesSpawnTime)
    {
        GameSessionManager.SetGameSessionTime(gameSessionTime);
        EnemiesSpawner.SetDelayToSpawnEnemies(enemiesSpawnTime);
    }

    private void OnDestroy()
    {
        if(GameSessionManager != null) GameSessionManager.OnGameSessionEnds -= StopGame;
    }
}
