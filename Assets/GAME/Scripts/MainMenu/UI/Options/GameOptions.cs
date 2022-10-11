using TMPro;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gameSessionTimeText;

    [SerializeField] private TextMeshProUGUI _enemySpawnTimeText;

    private int _gameSessionTime = 1;

    private float _enemySpawnTime = 1;

    private static GameOptions Instance;

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

        UpdateEnemySpawnTimeText();
        UpdateGameSessionTimeText();
    }

    private void Start() => ScenesManager.Instance.OnGameSceneLoaded += ApplyGameOptionsToGameManager;
    

    private void ApplyGameOptionsToGameManager()
    {
        GameManager.Instance.ApplyGameOptions(_gameSessionTime, _enemySpawnTime);
    }

    public void IncreaseGameSessionTime()
    {
        if (_gameSessionTime < 3) _gameSessionTime += 1;
        UpdateGameSessionTimeText();
    }

    public void DecreaseGameSessionTime()
    {
        if (_gameSessionTime > 1) _gameSessionTime -= 1;
        UpdateGameSessionTimeText();
    }

    public void IncreaseEnemySpawnTime()
    {
        if (_enemySpawnTime < 5) _enemySpawnTime += 0.5f;
        UpdateEnemySpawnTimeText();
    }

    public void DecreaseEnemySpawnTime()
    {
        if(_enemySpawnTime > 1) _enemySpawnTime -= 0.5f;
        UpdateEnemySpawnTimeText();
    }

    private void UpdateEnemySpawnTimeText()
    {
        _enemySpawnTimeText.text = _enemySpawnTime + " Seconds";
    }
    private void UpdateGameSessionTimeText()
    {
        _gameSessionTimeText.text = _gameSessionTime + " Minute";
    }
}
