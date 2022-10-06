using UnityEngine;

public class GameOptions : MonoBehaviour
{
    private int _gameSessionTime;
    private int _enemySpawnTime;

    public void SetGameSessionTime(int sessionTime)
    {
        _gameSessionTime = sessionTime;
    }

    public void SetEnemySpawnTime(int spawnTime)
    {
        _gameSessionTime = spawnTime;
    }
}
