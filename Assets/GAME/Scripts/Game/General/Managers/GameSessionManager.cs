using System;
using System.Collections;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    private int _gameSessionTime = 60;

    public event Action OnGameSessionEnds;

    public event Action OnGameSessionStarts;

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
        _gameSessionTime = sessionTime;
    }
}
