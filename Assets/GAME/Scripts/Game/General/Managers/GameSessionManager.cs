using System;
using System.Collections;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    private int _gameSessionTime = 60;

    public event Action OnGameSessionStopped;

    public event Action OnGameSessionStarts;

    private void Awake() => PlayerController.OnPlayerDied += StopGameSession;

    private void Start() => StartGameSession();

    private void StartGameSession()
    {
        OnGameSessionStarts?.Invoke();

        Time.timeScale = 1;

        StartCoroutine(GameSessionTimer());
    }

    private IEnumerator GameSessionTimer()
    {
        while (_gameSessionTime > 0)
        {
            _gameSessionTime -= 1;
            yield return new WaitForSecondsRealtime(1f);
        }

        StopGameSession();
    }

    private void StopGameSession()
    {
        OnGameSessionStopped?.Invoke();
        Time.timeScale = 0;
    }

    public void SetGameSessionTime(int sessionTime)
    { 
        _gameSessionTime = 60 * sessionTime;
    }

    private void OnDestroy() => PlayerController.OnPlayerDied -= StopGameSession;
}
