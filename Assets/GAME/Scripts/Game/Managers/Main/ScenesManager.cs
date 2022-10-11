using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    public event Action OnGameSceneLoaded;

    private const int GameSceneBuildIndex = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(Instance.gameObject);

        SceneManager.sceneLoaded += CheckIfCanInvokeOnGameSceneLoadedAction;
    }

    private void CheckIfCanInvokeOnGameSceneLoadedAction(Scene arg0, LoadSceneMode arg1)
    {
        if(SceneManager.GetActiveScene().buildIndex == GameSceneBuildIndex)
        {
            OnGameSceneLoaded?.Invoke();
        }
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        if (sceneIndex <= SceneManager.sceneCount && sceneIndex >= 0) SceneManager.LoadScene(sceneIndex);

        else throw new Exception("Does Not Exist Scene In The Index: " + sceneIndex);
    }
}
