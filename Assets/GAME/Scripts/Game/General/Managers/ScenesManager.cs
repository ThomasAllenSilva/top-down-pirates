using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    public event Action OnGameSceneLoaded;

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
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            OnGameSceneLoaded?.Invoke();
        }
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
