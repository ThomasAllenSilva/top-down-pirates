using System.Collections;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    public int _gameSessionTime;

    private void Start() => StartCoroutine(StartCountingGameSession());
    
    private IEnumerator StartCountingGameSession()
    {
        while (_gameSessionTime > 0)
        {
            _gameSessionTime -= 1;
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    public void SetGameSessionTime(int sessionTime)
    {
        _gameSessionTime = sessionTime;
    }
}
