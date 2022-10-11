using System;
using System.Collections;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    private int _gameSessionTime = 5;

    public event Action OnGameSessionEnds;

    public event Action OnGameSessionStarts;

    private void Awake()
    {
        PlayerController.OnPlayerDied += InvokeGameSessionEndsAction;
    }

    private void Start() => StartCoroutine(StartCountingGameSession());
    
    private IEnumerator StartCountingGameSession()
    {
        OnGameSessionStarts?.Invoke();

        while (_gameSessionTime > 0)
        {
            _gameSessionTime -= 1;
            yield return new WaitForSecondsRealtime(1f);
        }

        OnGameSessionEnds?.Invoke();
    }

    public void SetGameSessionTime(int sessionTime)
    { 
        _gameSessionTime = 60 * sessionTime;
    }

    private void InvokeGameSessionEndsAction()
    {
        OnGameSessionEnds?.Invoke();
    }

    private void OnDestroy()
    {
        PlayerController.OnPlayerDied -= InvokeGameSessionEndsAction;
    }
}
